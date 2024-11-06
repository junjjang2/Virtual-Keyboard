using System.Collections.Generic;
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

    public WordText selectedWord;
    
    public VowelSelect currentVowel;
    public VowelType currentVowelType;
    public ConsonantType currentConsonantType;
    
    bool isTriggered = false;
    
    int currentWordIndex = 0;
    
    public void Awake()
    {
        virtualKeyboard = new VirtualKeyboard();
        virtualKeyboard.EyeFlick.SetCallbacks(this);
        virtualKeyboard.Enable();

        // if PC
        words[currentWordIndex].SelectThis();
    }

    public void Update()
    {
        words.ForEach(word => word.EnableConsonant(currentConsonantType));

        if (selectedWord == null)
        {
            return;
        }

        if (currentVowel == VowelSelect.None)
        {
            if(isTriggered && !selectedWord.currentWord.Equals(' '))
                Debug.Log(selectedWord.currentWord);
            isTriggered = false;
        }
        
        selectedWord.SelectVowel(currentVowel);
        selectedWord.Ah.SetVowelType(currentVowelType);
        selectedWord.Oh.SetVowelType(currentVowelType);
        selectedWord.Oo.SetVowelType(currentVowelType);
        selectedWord.Uh.SetVowelType(currentVowelType);
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
            currentVowelType &= ~VowelType.Line;
        }
    }

    public void OnTab(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            currentWordIndex = (currentWordIndex + 1) % words.Count;
            words[currentWordIndex].SelectThis();
        }
    }
}
