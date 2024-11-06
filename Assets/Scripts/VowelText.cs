using System;
using TMPro;
using UnityEngine;

[Flags]
public enum VowelType
{
    Vowel,
    Line,
    Yi,
    
	LineYi = Line | Yi
}

public class VowelText : MonoBehaviour
{
    public TMP_Text vowel;
    public TMP_Text line;
    public TMP_Text yi;
    public TMP_Text lineyi;
    
    public VowelType currentType;

    // public void SetVowel(string vowel, string line, string yi, string lineyi)
    // {
    //     this.vowel.text = vowel;
    //     this.line.text = line;
    //     this.yi.text = yi;
    //     this.lineyi.text = lineyi;
    //     currentType = VowelType.Vowel;
    // }

	private char GetVowel(VowelType type)
    {
        return type switch
        {
            VowelType.Vowel => vowel.text[0],
            VowelType.Line => (line.text.Length > 0 ? line.text[0] : default),
            VowelType.Yi => (yi.text.Length > 0 ? yi.text[0] : default),
            VowelType.LineYi => (lineyi.text.Length > 0 ? lineyi.text[0] : default),
            _ => default
        };
    }
    
    public char GetCurrentVowel()
    {
        return GetVowel(currentType);
    }
    
    public void SetVowelType(VowelType type)
    {
        currentType = type;
        
        // disable all
        vowel.gameObject.SetActive(false);
        line.gameObject.SetActive(false);
        yi.gameObject.SetActive(false);
        lineyi.gameObject.SetActive(false);
        
        switch (type)
        {
            case VowelType.Vowel:
                vowel.gameObject.SetActive(true);
                break;
            case VowelType.Line:
                line.gameObject.SetActive(true);
                break;
            case VowelType.Yi:
                yi.gameObject.SetActive(true);
                break;
            case VowelType.LineYi:
                lineyi.gameObject.SetActive(true);
                break;
        }
    }

    public void DisableVowel()
    {
        currentType = VowelType.Vowel;
        // disable all
        vowel.gameObject.SetActive(false);
        line.gameObject.SetActive(false);
        yi.gameObject.SetActive(false);
        lineyi.gameObject.SetActive(false);
    }
}
