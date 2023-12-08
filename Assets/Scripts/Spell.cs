using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField] private string _spellName;
    [SerializeField] private int _spellIndex;
    [SerializeField] private float _spellRange;
    [SerializeField] private string _interactionLayerMask;

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
}
