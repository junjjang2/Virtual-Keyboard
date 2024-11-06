using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour, VirtualKeyboard.IEyeFlickActions
{
    public List<WordText> words;
    [SerializeField] public float deadZone = 0.2f;

    public void Awake()
    {
        VirtualKeyboard virtualKeyboard = new VirtualKeyboard();
        virtualKeyboard.EyeFlick.SetCallbacks(this);
        virtualKeyboard.Enable();
    }

    public void OnShift(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            words.ForEach(word => word.EnableConsonant(ConsonantType.Fortis));
        }
        else if(context.canceled)
        {
            words.ForEach(word => word.EnableConsonant(ConsonantType.Consonant));
        }
    }

    public void OnCtrl(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            words.ForEach(word => word.EnableConsonant(ConsonantType.Aspirated));
        }
        else if(context.canceled)
        {
            words.ForEach(word => word.EnableConsonant(ConsonantType.Consonant));
        }
    }

    // context : Vector2
    public void OnSelectVowel(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();
        if(value.y > deadZone) // down, ㅜ
        {
            words.ForEach(word => word.SelectVowel(VowelSelect.oo));
        }
        else if(value.y < -deadZone) // up, ㅗ
        {
            words.ForEach(word => word.SelectVowel(VowelSelect.oh));
        }
        else if(value.x > deadZone) // right, ㅏ
        {
            words.ForEach(word => word.SelectVowel(VowelSelect.a));
        }
        else if(value.x < -deadZone) // left, ㅓ
        {
            words.ForEach(word => word.SelectVowel(VowelSelect.uh));
        }
        else
        {
            words.ForEach(word => word.DisableAll());
        }
    }

    public void OnLine(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            words.ForEach(word =>
            {
                word.Ah.SetVowelType(VowelType.Line);
                word.Oh.SetVowelType(VowelType.Line);
                word.Oo.SetVowelType(VowelType.Line);
                word.Uh.SetVowelType(VowelType.Line);
            });
        }
        else if (context.canceled)
        {
            words.ForEach(word =>
            {
                word.Ah.SetVowelType(VowelType.Vowel);
                word.Oh.SetVowelType(VowelType.Vowel);
                word.Oo.SetVowelType(VowelType.Vowel);
                word.Uh.SetVowelType(VowelType.Vowel);
            });
        }
    }

    public void OnYi(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            words.ForEach(word =>
            {
                word.Ah.SetVowelType(VowelType.Yi);
                word.Oh.SetVowelType(VowelType.Yi);
                word.Oo.SetVowelType(VowelType.Yi);
                word.Uh.SetVowelType(VowelType.Yi);
            });
        }
        else if (context.canceled)
        {
            words.ForEach(word =>
            {
                word.Ah.SetVowelType(VowelType.Vowel);
                word.Oh.SetVowelType(VowelType.Vowel);
                word.Oo.SetVowelType(VowelType.Vowel);
                word.Uh.SetVowelType(VowelType.Vowel);
            });
        }
    }
}
