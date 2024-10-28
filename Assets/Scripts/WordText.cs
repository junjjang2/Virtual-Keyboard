using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VowelSelect
{
    a,
    oh,
    oo,
    uh,
}

public class WordText : MonoBehaviour
{
    public ConsonantText consonant;

    public VowelText Ah;
    public VowelText Oh;
    public VowelText Oo;
    public VowelText Uh;
    
    public void SetWord(string consonant, string fortis, string aspirated, string vowel, string line, string yi, string lineyi)
    {
        this.consonant.SetConsonant(consonant, fortis, aspirated);
    }
    
    public string GetConsonant(ConsonantType type)
    {
        return consonant.GetConsonant(type);
    }
    
    public void EnableConsonant(ConsonantType type)
    {
        consonant.EnableConsonant(type);
    }
    
    public void SelectVowel(VowelSelect select)
    {
        Ah.gameObject.SetActive(false);
        Oh.gameObject.SetActive(false);
        Oo.gameObject.SetActive(false);
        Uh.gameObject.SetActive(false);
        
        switch (select)
        {
            case VowelSelect.a:
                Debug.Log(Ah.GetCurrentVowel());
                Ah.gameObject.SetActive(true);
                break;
            case VowelSelect.oh:
                Debug.Log(Oh.GetCurrentVowel());
                Oh.gameObject.SetActive(true);
                break;
            case VowelSelect.oo:
                Debug.Log(Oo.GetCurrentVowel());
                Oo.gameObject.SetActive(true);
                break;
            case VowelSelect.uh:
                Debug.Log(Uh.GetCurrentVowel());
                Uh.gameObject.SetActive(true);
                break;
        }
    }
    
    public void EnableVowel(VowelText vowel)
    {
        vowel.gameObject.SetActive(true);
    }
    
    public void EnableAll()
    {
        EnableConsonant(ConsonantType.Consonant);
        Ah.gameObject.SetActive(true);
        Oh.gameObject.SetActive(true);
        Oo.gameObject.SetActive(true);
        Uh.gameObject.SetActive(true);
    }
}