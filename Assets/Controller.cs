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
        
        previewText.text = HangulCombiner.CombineHangul(cho, jung, jong).ToString();
        
        // 종성은 선택 X (초성 입력을 중성 입력으로 전달)
        
        // if (currentVowel == VowelSelect.None)
        // {
        //     if (isTriggered && !selectedWord.currentWord.Equals(' '))
        //     {
        //         // currentWord = selectedWord.currentWord;
        //         // EnterWord();
        //     }
        //     isTriggered = false;
        // }
    }
    
    public void EnqueueWord(char word)
    {
        switch (currentState)
        {
            case WordState.None:
                cho = word;
                var state = HangulCombiner.GetWordState(word);
                currentState = state;
                break;
            case WordState.cho:
                // 중성이 아니라면 입력 X
                if (HangulCombiner.GetWordState(word) != WordState.jung)
                {
                    return;
                }
                jung = word;
                currentState = WordState.jung;
                break;
            case WordState.jung:
                // 종성이 입력되었는 지 확인
                if(HangulCombiner.GetWordState(word) == WordState.jong)
                {
                    jong = word;
                    currentState = WordState.jong;
                }
                if(HangulCombiner.GetWordState(word) == WordState.cho)
                {
                    jong = word;
                    currentState = WordState.jong;
                }
                break;
        }
    }
    
    public void EnterWord()
    {
        // 자음을 추가하는데 이전에 초성이랑 중성만 있으면 종성을 추가함
        var canAddJong = CanAddJong();
        if(canAddJong != '\0')
        {
            PopWord();
            virtualKeyboardView.text += HangulCombiner.CombineHangul(prevCho, prevJung, canAddJong);
            cho = prevCho;
            jung = prevJung;
            jong = canAddJong;
        }
        else
        {
            virtualKeyboardView.text += HangulCombiner.CombineHangul(cho, jung, jong);
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
        if (cho != '\0' && jung == '\0' && jong == '\0')
        {
            // 단자음이면 true
            if (prevJong == '\0')
            {
                return cho;
            }
            else if(jongComb.ContainsKey(prevJong) && jongComb[prevJong].ContainsKey(cho)) 
                return jongComb[prevJong][cho];
            else
            {
                return '\0';
            }
        }
        
        return '\0';
    }

    private void PopWord()
    {
        // char last = virtualKeyboardView.text[^1];
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

    public void OnShift(InputAction.CallbackContext context)
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

    public void OnCtrl(InputAction.CallbackContext context)
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
        if(value.y > deadZone) // down, ㅜ
        {
            // words.ForEach(word => word.SelectVowel(VowelSelect.oo));
            currentVowel = VowelSelect.oo;
            isTriggered = true;
        }
        else if(value.y < -deadZone) // up, ㅗ
        {
            // words.ForEach(word => word.SelectVowel(VowelSelect.oh));
            currentVowel = VowelSelect.oh;
            isTriggered = true;
        }
        else if(value.x > deadZone) // right, ㅏ
        {
            // words.ForEach(word => word.SelectVowel(VowelSelect.a));
            currentVowel = VowelSelect.a;
            isTriggered = true;
        }
        else if(value.x < -deadZone) // left, ㅓ
        {
            // words.ForEach(word => word.SelectVowel(VowelSelect.uh));
            currentVowel = VowelSelect.uh;
            isTriggered = true;
        }

        if (context.canceled)
        {
            currentVowel = VowelSelect.None;
        }
    }

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

    public void OnTab(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            words[currentWordIndex].DeselectThis();
            currentWordIndex = (currentWordIndex + 1) % words.Count;
            words[currentWordIndex].SelectThis();
        }
    }

    public void OnSpace(InputAction.CallbackContext context)
    {
        Debug.Log(' ');
        virtualKeyboardView.text += ' ';
    }

    /// <summary>
    /// 글자 입력
    /// </summary>
    /// <param name="context"></param>
    public void OnSelect(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            // var tmp = virtualKeyboardView.text;
            // var c = tmp[^1];
            //
            EnterWord();
        }
    }
}
