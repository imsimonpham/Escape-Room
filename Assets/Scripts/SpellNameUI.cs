using TMPro;
using UnityEngine;

public class SpellNameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _spellNameText;
    [SerializeField] private GameObject _spellFrame;
    
    public void UpdateSpellNameText(string text)
    {
        _spellNameText.text = text;
    }

    public void ShowSpellFrame()
    {
        _spellFrame.SetActive(true);
    }
    
    public void HideSpellFrame()
    {
        _spellFrame.SetActive(false);
    }
}
