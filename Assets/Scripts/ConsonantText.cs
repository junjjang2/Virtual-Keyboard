using TMPro;
using UnityEngine;

public enum ConsonantType
{
    // 초성
    Consonant,
    // 된소리
    Fortis,
    // 거센소리
    Aspirated
}

public class ConsonantText : MonoBehaviour
{
    public TMP_Text consonant;
    public TMP_Text fortis;
    public TMP_Text aspirated;

    public ConsonantType currentType;

    public char CurrentText
    {
        get
        {
            switch (currentType)
            {
                case ConsonantType.Consonant:
                    return (consonant.text.Length > 0 ? consonant.text[0] : default);
                case ConsonantType.Fortis:
                    return (fortis.text.Length > 0 ? fortis.text[0] : default);
                case ConsonantType.Aspirated:
                    return (aspirated.text.Length > 0 ? aspirated.text[0] : default);
                default:
                    return default;
            }
        }
    } 
    
    public void SetConsonant(string consonant, string fortis, string aspirated)
    {
        this.consonant.text = consonant;
        this.fortis.text = fortis;
        this.aspirated.text = aspirated;
    }
    
    public string GetConsonant(ConsonantType type)
    {
        return type switch
        {
            ConsonantType.Consonant => consonant.text,
            ConsonantType.Fortis => fortis.text,
            ConsonantType.Aspirated => aspirated.text,
            _ => ""
        };
    }
    
    public void EnableConsonant(ConsonantType type)
    {
        // disable all
        consonant.gameObject.SetActive(false);
        fortis.gameObject.SetActive(false);
        aspirated.gameObject.SetActive(false);
        
        currentType = type;
        
        switch (currentType)
        {
            case ConsonantType.Consonant:
                consonant.gameObject.SetActive(true);
                break;
            case ConsonantType.Fortis:
                fortis.gameObject.SetActive(true);
                break;
            case ConsonantType.Aspirated:
                aspirated.gameObject.SetActive(true);
                break;
        }
    }
}
