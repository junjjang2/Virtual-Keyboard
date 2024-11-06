using UnityEngine;
using UnityEngine.UI;

public enum VowelSelect
{
    None,
    a,
    oh,
    oo,
    uh,
}

public class WordText : MonoBehaviour
{
    public ConsonantText consonant;

    public VowelSelect currentVowel;
    public VowelType currentVowelType;
    
    public VowelText Ah;
    public VowelText Oh;
    public VowelText Oo;
    public VowelText Uh;

    public Image image;

    public char CurrentVowel
    {
        get
        {
            switch (currentVowel)
            {
                case VowelSelect.a:
                    return Ah.GetCurrentVowel();
                case VowelSelect.oh:
                    return Oh.GetCurrentVowel();
                case VowelSelect.oo:
                    return Oo.GetCurrentVowel();
                case VowelSelect.uh:
                    return Uh.GetCurrentVowel();
                default:
                    return default;
            }
        }
    }

    public char currentWord;
    
    public void Update()
    {
        var cons = consonant.CurrentText;
        var vowel = CurrentVowel;
        var finalSound = default(char);
        var combined = HangulCombiner.CombineHangul(cons, vowel);
        
        if (combined != cons)
        {
            currentWord = combined;
        }
        else
        {
            currentWord = cons;
        }
    }

    public void SelectThis()
    {
        Controller.Instance.selectedWord = this;
        image.color = Color.white;
    }

    public void DeselectThis()
    {
        if(Controller.Instance.selectedWord == this)
            Controller.Instance.selectedWord = null;
        image.color = Color.gray;
        DisableAll();
    }

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
        currentVowel = select;
        
        Ah.gameObject.SetActive(false);
        Oh.gameObject.SetActive(false);
        Oo.gameObject.SetActive(false);
        Uh.gameObject.SetActive(false);
        
        switch (select)
        {
            case VowelSelect.a:
                Ah.gameObject.SetActive(true);
                break;
            case VowelSelect.oh:
                Oh.gameObject.SetActive(true);
                break;
            case VowelSelect.oo:
                Oo.gameObject.SetActive(true);
                break;
            case VowelSelect.uh:
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

    public void DisableAll()
    {
        currentVowel = VowelSelect.None;
        Ah.gameObject.SetActive(false);
        Oh.gameObject.SetActive(false);
        Oo.gameObject.SetActive(false);
        Uh.gameObject.SetActive(false);
    }
}