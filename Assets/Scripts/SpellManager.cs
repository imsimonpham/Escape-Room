using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class SpellManager : MonoBehaviour
{
   [SerializeField] private GameObject[] _spells;
   [SerializeField] private SpellNameUI _spellNameUI;
   [SerializeField] private SpellDetailsUI _spellDetailsUI;
   [SerializeField] private InputActionReference _nextSpellReference = null;
   [SerializeField] private InputActionReference _previousSpellReference = null;
   [SerializeField] private RightHand _rightHand;
   [SerializeField] private XRRayInteractor _xrRayInteractor;
   private int _currentSpellIndex;
   private bool _wandIsActivated = false;
   private Spell _currentSpell;

    //Audio
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _switchSound;

   void Awake()
   {
      _nextSpellReference.action.started += NextSpell;
      _previousSpellReference.action.started += PreviousSpell;
   }

   void Update()
   {
      _currentSpell = _spells[_currentSpellIndex].GetComponent<Spell>();
      _spellNameUI.UpdateSpellNameText(_currentSpell.GetSpellName());
      _spellDetailsUI.UpdateSpellUseText(_currentSpell.GetSpellUse());
      _spellDetailsUI.UpdateSpellRangeText(_currentSpellIndex, _currentSpell.GetSpellRange());
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
      _rightHand.UpdateRayRange(_currentSpell.GetSpellRange());
      //update interaction layer mask
      UpdateInteractionLayerMask();
   }
   
   public void DeactivateWand()
   {
      _wandIsActivated = false;
   }
   
   public void NextSpell(InputAction.CallbackContext context)
   {
        if (_wandIsActivated)
        {
            //Audio cue
            _audioSource.PlayOneShot(_switchSound);
            _spells[_currentSpellIndex].SetActive(false);
            _currentSpellIndex = (_currentSpellIndex + 1) % _spells.Length;
            _spells[_currentSpellIndex].SetActive(true);
            //update range
            _rightHand.UpdateRayRange(_currentSpell.GetSpellRange());
            //update interaction layer mask
            UpdateInteractionLayerMask();
        }
   }
   
   public void PreviousSpell(InputAction.CallbackContext context)
   {
        if (_wandIsActivated)
        {
            //Audio cue
            _audioSource.PlayOneShot(_switchSound);
            _spells[_currentSpellIndex].SetActive(false);
            _currentSpellIndex = ((_currentSpellIndex - 1) + _spells.Length) % _spells.Length;
            _spells[_currentSpellIndex].SetActive(true);
            //update range
            _rightHand.UpdateRayRange(_currentSpell.GetSpellRange());
            //update interaction layer mask
            UpdateInteractionLayerMask();
        }     
   }

   public void SwitchToManipulix()
   {
        _spells[_currentSpellIndex].SetActive(false);
        _currentSpellIndex = 5;
        _spells[_currentSpellIndex].SetActive(true);
        //update range
        _rightHand.UpdateRayRange(_currentSpell.GetSpellRange());
        //update interaction layer mask
        UpdateInteractionLayerMask();
    }
    

   public Spell GetCurrentSpell()
   {
      return _spells[_currentSpellIndex].GetComponent<Spell>();
   }

   void UpdateInteractionLayerMask()
   {
      string interactionLayerMask = _currentSpell.GetSpellInteractionLayerMask();
      _xrRayInteractor.interactionLayers  = InteractionLayerMask.GetMask(interactionLayerMask);
   }
}
