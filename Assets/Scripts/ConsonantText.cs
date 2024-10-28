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
    
    public void SetConsonant(string consonant, string fortis, string aspirated)
    {
        this.consonant.text = consonant;
        this.fortis.text = fortis;
        this.aspirated.text = aspirated;
    }
    
    public string GetConsonant(ConsonantType type)
    {
        switch (type)
        {
            case ConsonantType.Consonant:
                return consonant.text;
            case ConsonantType.Fortis:
                return fortis.text;
            case ConsonantType.Aspirated:
                return aspirated.text;
        }
        
        return "";
    }
    
    public void EnableConsonant(ConsonantType type)
    {
        // disable all
        consonant.gameObject.SetActive(false);
        fortis.gameObject.SetActive(false);
        aspirated.gameObject.SetActive(false);
        
        switch (type)
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
