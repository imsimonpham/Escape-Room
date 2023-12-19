using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class SpellDetailsUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _spellUseText;
    [SerializeField] private TMP_Text _spellRangeText;
    [SerializeField] private GameObject _background;
    [SerializeField] private InputActionReference _toggleSpellDetailsReference;
    private bool _showBg;

    void Awake()
    {
        _toggleSpellDetailsReference.action.started += ToggleSpellDetails;
    }

    public void UpdateSpellUseText(string text)
    {
        _spellUseText.text = "Use: " + text;
    }

    public void UpdateSpellRangeText(int index, float range)
    {
        if (index == 2)
        {
            _spellRangeText.text = "Range: around caster's wand";
        } else
        {
            _spellRangeText.text = "Range: " + range + " meters";
        }
    }

    public void ToggleBg()
    {
        if (_showBg)
        {
            ShowBg();
        } else
        {
            HideBg();
        }
    }

    public void ShowBg()
    {
        _background.SetActive(true);
    }

    public void HideBg()
    {
        _background.SetActive(false);
    }

    void ToggleSpellDetails(InputAction.CallbackContext context) {
        _showBg = !_showBg;
    }
}
