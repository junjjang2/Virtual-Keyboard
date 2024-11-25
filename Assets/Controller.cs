using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour, VirtualKeyboard.IEyeFlickActions
{
    public static Controller Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<Controller>();
            }
            return _instance;
        }
    }

    private static Controller _instance;
    
    public List<WordText> words;
    [SerializeField] public float deadZone = 0.2f;
    private VirtualKeyboard virtualKeyboard;
    
    [SerializeField] public TMP_Text virtualKeyboardView;
    [SerializeField] public TMP_Text previewText;

    public WordText selectedWord;
    
    public VowelSelect currentVowel;
    public VowelType currentVowelType;
    public ConsonantType currentConsonantType;
    
    bool isTriggered = false;
    
    int currentWordIndex = 0;
    
    // char currentWord = ' ';
    
    char cho = '\0';
    char jung = '\0';
    char jong = '\0';
    
    char prevCho = '\0';
    char prevJung = '\0';
    char prevJong = '\0';
    
    WordState currentState = WordState.None;

    private const char ReturnText = '\n';

    public void Awake()
    {
        virtualKeyboard = new VirtualKeyboard();
        virtualKeyboard.EyeFlick.SetCallbacks(this);
        virtualKeyboard.Enable();

        virtualKeyboardView.text = "";
        // if PC
    #if UNITY_EDITOR_WIN
        words.ForEach(word => word.DeselectThis());
    #endif
    }

    public void Update()
    {
        // 초성 변경자를 적용
        words.ForEach(word => word.EnableConsonant(currentConsonantType));

        if (selectedWord == null)
        {
            return;
        }
        
        // 초성을 선택
        cho = selectedWord.consonant.CurrentText;
        
        // 중성 변경자를 적용
        selectedWord.SetVowelType(currentVowelType);
        
        // 중성을 선택
        selectedWord.SelectVowel(currentVowel);
        jung = selectedWord.CurrentVowel;
        
        previewText.text = HangeulCombiner.CombineHangul(cho, jung, jong).ToString();
        
        // 종성은 선택 X (초성 입력을 중성 입력으로 전달)
    }
    
    public void EnterWord()
    {
        // 자음을 추가하는데 이전에 초성이랑 중성만 있으면 종성을 추가함
        var canAddJong = CanAddJong();
        if(canAddJong != '\0')
        {
            PopWord();
            virtualKeyboardView.text += HangeulCombiner.CombineHangul(prevCho, prevJung, canAddJong);
            cho = prevCho;
            jung = prevJung;
            jong = canAddJong;
        }
        else
        {
            virtualKeyboardView.text += HangeulCombiner.CombineHangul(cho, jung, jong);
        }
        ResetWord();
    }

    private Dictionary<char, Dictionary<char, char>> jongComb = new()
    {
        ['ㄱ'] = new Dictionary<char, char> { { 'ㅅ', 'ㄳ' } },
        ['ㄴ'] = new Dictionary<char, char> { { 'ㅈ', 'ㄵ' }, {'ㅎ', 'ㄶ' } },
        ['ㄹ'] = new Dictionary<char, char> { { 'ㄱ', 'ㄺ' }, {'ㅁ', 'ㄻ' }, {'ㅂ', 'ㄼ' }, {'ㅅ', 'ㄽ' }, {'ㅌ', 'ㄾ' }, {'ㅍ', 'ㄿ' }, {'ㅎ', 'ㅀ' } },
        ['ㅂ'] = new Dictionary<char, char> { { 'ㅅ', 'ㅄ' } }
    };
    
    private char CanAddJong()
    {
        // 종성을 추가할 수 있는 상태인 지 확인
        if (cho == '\0' || jung != '\0' || jong != '\0') return '\0';
        
        // 종성이 없다면 true
        if (prevJong == '\0')
            return cho;
            
        // 종성이 단자음이면 가능한 조합인지 확인
        if(jongComb.ContainsKey(prevJong) && jongComb[prevJong].ContainsKey(cho)) 
            return jongComb[prevJong][cho];
            
        // 가능한 조합이 없다면 종성을 추가하지 않음
        return '\0';

    }

    private void PopWord()
    {
        // char last = virtualKeyboardView.text[^1];
        if(virtualKeyboardView.text.Length == 0) return;
        virtualKeyboardView.text = virtualKeyboardView.text.Remove(virtualKeyboardView.text.Length - 1);
    }

    public void ResetWord()
    {
        prevCho  = cho;
        prevJung = jung;
        prevJong = jong;
        
        cho  = '\0';
        jung = '\0';
        jong = '\0';
    }

    // 된소리
    public void OnFortis(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            currentConsonantType = ConsonantType.Fortis;
        }
        else if(context.canceled)
        {
            currentConsonantType = ConsonantType.Consonant;
        }
    }

    // 거센소리
    public void OnAspirated(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            currentConsonantType = ConsonantType.Aspirated;
        }
        else if(context.canceled)
        {
            currentConsonantType = ConsonantType.Consonant;
        }
    }

    // context : Vector2
    public void OnSelectVowel(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();
        if(value.y < -deadZone && value.x < -deadZone)
        {
            currentVowel = VowelSelect.wo;
            isTriggered = true;
        }
        else if (value.y > deadZone && value.x > deadZone)
        {
            currentVowel = VowelSelect.wa;
            isTriggered = true;
        }
        else if(value.y < -deadZone)
        {
            currentVowel = VowelSelect.oo;
            isTriggered = true;
        }
        else if(value.y > deadZone)
        {
            currentVowel = VowelSelect.oh;
            isTriggered = true;
        }
        else if(value.x > deadZone)
        {
            currentVowel = VowelSelect.a;
            isTriggered = true;
        }
        else if(value.x < -deadZone)
        {
            currentVowel = VowelSelect.uh;
            isTriggered = true;
        }

        if (context.canceled)
        {
            currentVowel = VowelSelect.None;
        }
    }

    // 가로획 추가 (ㅡ)
    public void OnLine(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            currentVowelType |= VowelType.Line;
        }
        else if (context.canceled)
        {
            currentVowelType &= ~VowelType.Line;
        }
    }

    // 세로획 추가 (ㅣ)
    public void OnYi(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            currentVowelType |= VowelType.Yi;
        }
        else if (context.canceled)
        {
            currentVowelType &= ~VowelType.Yi;
        }
    }
    
    // PC : 선택 자음 변경
    public void OnTab(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            words[currentWordIndex].DeselectThis();
            currentWordIndex = (currentWordIndex + 1) % words.Count;
            words[currentWordIndex].SelectThis();
        }
    }

    public void OnDelete(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PopWord();
        }
    }

    public void OnEnter(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            virtualKeyboardView.text += ReturnText;
            ResetWord();
        }
    }

    // 공백 자음 추가
    public void OnSpace(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            virtualKeyboardView.text += ' ';
            ResetWord();
        }
    }

    /// <summary>
    /// 글자 입력
    /// </summary>
    /// <param name="context"></param>
    public void OnSelect(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            EnterWord();
        }
    }
}
