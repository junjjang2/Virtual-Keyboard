using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    public Image image;
    public TMP_Text vowel;
    public TMP_Text line;
    public TMP_Text yi;
    public TMP_Text lineyi;

    public TMP_Text PreviewLine;
    public TMP_Text PreviewYi;
    public TMP_Text PreviewLineYi;


#if UNITY_EDITOR
    public void OnValidate()
    {
        if (PreviewLine != null)
        {
            PreviewLine.text = line.text;
        }
        if (PreviewYi != null)
        {
            PreviewYi.text = yi.text;
        }
        if (PreviewLineYi != null)
        {
            PreviewLineYi.text = lineyi.text;
        }
    }
#endif
    
    public VowelType currentType;

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

    public void Dim()
    {
        image.color = Color.gray;
    }
    
    public void Bright()
    {
        image.color = new Color(1f, 0.98f, 0.6f, 1f);
    }
}
