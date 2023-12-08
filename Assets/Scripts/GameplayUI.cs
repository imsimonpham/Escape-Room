using TMPro;
using UnityEngine;

public class GameplayUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _spellNameText;
    [SerializeField] private GameObject _spellFrame;
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _wand;
    [SerializeField] private float _distance;
    
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
