using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpellManager : MonoBehaviour
{
   [SerializeField] private GameObject[] _spells;
   [SerializeField] private GameplayUI _gameplayUI;
   //[SerializeField] private InputActionReference _changeSpell = null;
   private int _currentIndex;

   void Update()
   {
      _gameplayUI.UpdateSpellNameText(_currentIndex.ToString());
   }
   

   public void ChangeSpell()
   {
      _currentIndex++;
      Debug.Log(_currentIndex);
   }
   
   /*
    // Deactivate the current spell
      _spells[_currentSpellIndex].SetActive(false);

      // Increment the index to switch to the next spell
      _currentSpellIndex = (_currentSpellIndex + 1) % _spells.Length;

      // Activate the new spell
      _spells[_currentSpellIndex].SetActive(true);
   */
}
