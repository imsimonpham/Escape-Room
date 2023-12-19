using TMPro;
using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField] private string _spellName;
    [SerializeField] private int _spellIndex;
    [SerializeField] private float _spellRange;
    [SerializeField] private string _interactionLayerMask;
    [SerializeField] private string _spellUse;
    [SerializeField] private AudioClip _spellSound;

    public string GetSpellName()
    {
        return _spellName;
    }
    
    public int GetSpellIndex()
    {
        return _spellIndex;
    }
    
    public float GetSpellRange()
    {
        return _spellRange;
    }

    public string GetSpellInteractionLayerMask()
    {
        return _interactionLayerMask;
    }

    public string GetSpellUse()
    {
        return _spellUse;
    }

    public AudioClip GetSpellSound()
    {
        return _spellSound;
    }
}
