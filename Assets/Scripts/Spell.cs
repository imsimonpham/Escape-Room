using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField] private string _spellName;
    [SerializeField] private int _spellIndex;

    public string GetSpellName()
    {
        return _spellName;
    }
    
    public int GetSpellIndex()
    {
        return _spellIndex;
    }
}
