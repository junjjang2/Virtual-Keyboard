using UnityEngine;
using UnityEngine.UI;

public enum VowelSelect
{
    None,
    wo,
    wa,
    a,
    oh,
    oo,
    uh
}

public class WordText : MonoBehaviour
{
    public ConsonantText consonant;

    public VowelSelect currentVowel;
    public VowelType currentVowelType;
    
    // 단모음
    [Header("단모음")]
    public VowelText Ah;
    public VowelText Oh;
    public VowelText Oo;
    public VowelText Uh;

    // 이중모음
    [Header("이중모음")]
    public VowelText Wa; // ㅘ
    public VowelText Wo; // ㅝ
    public VowelText LineYi; // ㅢ
    
    // 기본자
    [Header("기본자")]
    public VowelText Yi; // ㅣ
    public VowelText Line; // ㅡ
    
    
    public Image image;

    public char CurrentVowel
    {
        get
        {
            switch (currentVowel)
            {
                case VowelSelect.wo:
                    return Wo.GetCurrentVowel();
                case VowelSelect.wa:
                    return Wa.GetCurrentVowel();
                case VowelSelect.a:
                    return Ah.GetCurrentVowel();
                case VowelSelect.oh:
                    return Oh.GetCurrentVowel();
                case VowelSelect.oo:
                    return Oo.GetCurrentVowel();
                case VowelSelect.uh:
                    return Uh.GetCurrentVowel();
                default:
                    return currentVowelType switch
                    {
                        VowelType.Line => 'ㅡ',
                        VowelType.Yi => 'ㅣ',
                        VowelType.LineYi => 'ㅢ',
                        _ => default
                    };
            }
        }
    }

    public char currentWord;
    
    public void Update()
    {
        var cons = consonant.CurrentText;
        var vowel = CurrentVowel;
        var combined = HangeulCombiner.CombineHangul(cons, vowel);
        
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
    
    public void SetVowelType(VowelType type)
    {
        currentVowelType = type;
        Wo.SetVowelType(currentVowelType);
        Wa.SetVowelType(currentVowelType);
        Ah.SetVowelType(currentVowelType);
        Oh.SetVowelType(currentVowelType);
        Oo.SetVowelType(currentVowelType);
        Uh.SetVowelType(currentVowelType);
    }
    
    public void SelectVowel(VowelSelect select)
    {
        currentVowel = select;
        
        Wo.gameObject.SetActive(false);
        Wa.gameObject.SetActive(false);
        Ah.gameObject.SetActive(false);
        Oh.gameObject.SetActive(false);
        Oo.gameObject.SetActive(false);
        Uh.gameObject.SetActive(false);
        
        Line.gameObject.SetActive(false);
        Yi.gameObject.SetActive(false);
        LineYi.gameObject.SetActive(false);
        
        switch (select)
        {
            case VowelSelect.wo:
                Wo.gameObject.SetActive(true);
                break;
            case VowelSelect.wa:
                Wa.gameObject.SetActive(true);
                break;
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
            default:
                switch (currentVowelType)
                {
                    case VowelType.Line:
                        Line.gameObject.SetActive(true);
                        break;
                    case VowelType.Yi:
                        Yi.gameObject.SetActive(true);
                        break;
                    case VowelType.LineYi:
                        LineYi.gameObject.SetActive(true);
                        break;
                }
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
        Wo.gameObject.SetActive(true);
        Wa.gameObject.SetActive(true);
        Ah.gameObject.SetActive(true);
        Oh.gameObject.SetActive(true);
        Oo.gameObject.SetActive(true);
        Uh.gameObject.SetActive(true);
    }

    public void DisableAll()
    {
        currentVowel = VowelSelect.None;
        Wo.gameObject.SetActive(false);
        Wa.gameObject.SetActive(false);
        Ah.gameObject.SetActive(false);
        Oh.gameObject.SetActive(false);
        Oo.gameObject.SetActive(false);
        Uh.gameObject.SetActive(false);
        Line.gameObject.SetActive(false);   
        Yi.gameObject.SetActive(false);
        LineYi.gameObject.SetActive(false);
    }
}