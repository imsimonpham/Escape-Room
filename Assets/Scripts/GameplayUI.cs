using TMPro;
using UnityEngine;

public class GameplayUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _spellNameText;

    public void UpdateSpellNameText(string text)
    {
        _spellNameText.text = text;
    }
}
