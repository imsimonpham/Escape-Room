using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class SpellManager : MonoBehaviour
{
   [SerializeField] private GameObject[] _spells;
   [SerializeField] private GameplayUI _gameplayUI;
   [SerializeField] private InputActionReference _nextSpellReference = null;
   [SerializeField] private InputActionReference _previousSpellReference = null;
   [SerializeField] private RightHand _rightHand;
   [SerializeField] private XRRayInteractor _xrRayInteractor;
   private int _currentSpellIndex;
   private bool _wandIsActivated = false;

   void Awake()
   {
      _nextSpellReference.action.started += NextSpell;
      _previousSpellReference.action.started += PreviousSpell;
   }

   void Update()
   {
      _gameplayUI.UpdateSpellNameText(_spells[_currentSpellIndex].GetComponent<Spell>().GetSpellName());
      if (!_wandIsActivated)
      {
         foreach (GameObject spell in _spells)
         {
            spell.SetActive(false);
         }
      }
      else
      {
         _spells[_currentSpellIndex].SetActive(true);
      }
   }

   public void ActivateWand()
   {
      _wandIsActivated = true;
      //update range
      _rightHand.UpdateRayRange(_spells[_currentSpellIndex].GetComponent<Spell>().GetSpellRange());
      //update interaction layer mask
      UpdateInteractionLayerMask();
   }
   
   public void DeactivateWand()
   {
      _wandIsActivated = false;
   }
   
   public void NextSpell(InputAction.CallbackContext context)
   {
      _spells[_currentSpellIndex].SetActive(false);
      _currentSpellIndex = (_currentSpellIndex + 1) % _spells.Length;
      _spells[_currentSpellIndex].SetActive(true);
      //update range
      _rightHand.UpdateRayRange(_spells[_currentSpellIndex].GetComponent<Spell>().GetSpellRange());
      //update interaction layer mask
      UpdateInteractionLayerMask();
   }
   
   public void PreviousSpell(InputAction.CallbackContext context)
   {
      _spells[_currentSpellIndex].SetActive(false);
      _currentSpellIndex = ((_currentSpellIndex - 1) + _spells.Length) % _spells.Length;
      _spells[_currentSpellIndex].SetActive(true);
      //update range
      _rightHand.UpdateRayRange(_spells[_currentSpellIndex].GetComponent<Spell>().GetSpellRange());
      //update interaction layer mask
      UpdateInteractionLayerMask();
   }

   public int GetCurrentSpellIndex()
   {
      return _currentSpellIndex;
   }

   void UpdateInteractionLayerMask()
   {
      string interactionLayerMask = _spells[_currentSpellIndex].GetComponent<Spell>().GetSpellInteractionLayerMask();
      _xrRayInteractor.interactionLayers  = InteractionLayerMask.GetMask(interactionLayerMask);
   }
}
