using TMPro;
using UnityEngine;

public enum VowelType
{
    Vowel,
    Line,
    Yi,
	LineYi
}

public class VowelText : MonoBehaviour
{
    public TMP_Text vowel;
    public TMP_Text line;
    public TMP_Text yi;
    public TMP_Text lineyi;
    
    public VowelType currentType;

    public void SetVowel(string vowel, string line, string yi, string lineyi)
    {
        this.vowel.text = vowel;
        this.line.text = line;
        this.yi.text = yi;
        this.lineyi.text = lineyi;
        currentType = VowelType.Vowel;
    }

	public string GetVowel(VowelType type)
    {
        switch (type)
        {
            case VowelType.Vowel:
                return vowel.text;
            case VowelType.Line:
                return line.text;
            case VowelType.Yi:
                return yi.text;
            case VowelType.LineYi:
                return lineyi.text;
        }

        return "";
    }
    
    public string GetCurrentVowel()
    {
        return GetVowel(currentType);
    }
    
    public void SetVowelType(VowelType type)
    {
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
        // disable all
        vowel.gameObject.SetActive(false);
        line.gameObject.SetActive(false);
        yi.gameObject.SetActive(false);
        lineyi.gameObject.SetActive(false);
    }
}
