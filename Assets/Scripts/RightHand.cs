using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class RightHand : MonoBehaviour
{
   [SerializeField] private XRDirectInteractor _xrDirectInteractor;
   [SerializeField] private Animator _animator;
   [SerializeField] private XRInteractorLineVisual _lineVisual;
   [SerializeField] private XRRayInteractor _xrRayInteractor;
   [SerializeField] private GameplayUI _gameplayUI;
   [SerializeField] private SpellManager _spellManager;
   [SerializeField] private InputActionReference _useSpellReference;
   [SerializeField] private ActionBasedController _xrController;
   private int _currentSpellIndex;
   void Awake()
   {
       _useSpellReference.action.started += UseSpell;
   }
   
    void Update()
    {
        if (_animator != null)
        {
            CheckForWand();
        }
    }

    public void CheckForWand()
    {
        var interactables = _xrDirectInteractor.interactablesSelected;
        
        if (interactables != null && interactables.Count > 0)
        {
            _animator.SetBool("HoldingWand", true);
            _lineVisual.enabled = true;
            _xrRayInteractor.enabled = true;
            _gameplayUI.ShowSpellFrame();
            _spellManager.ActivateWand();
        }
        else
        {
            _animator.SetBool("HoldingWand", false);
            _lineVisual.enabled = false;
            _xrRayInteractor.enabled = false;
            _gameplayUI.HideSpellFrame();
            _spellManager.DeactivateWand();
        }
    }

    public void AssignAnimator(Animator anim)
    {
        _animator = anim;
    }

    public void UpdateRayRange(float spellRange)
    {
        _lineVisual.lineLength = spellRange;
        _xrRayInteractor.maxRaycastDistance = spellRange;
    }

    public void UseSpell(InputAction.CallbackContext context)
    {
        _currentSpellIndex = _spellManager.GetCurrentSpellIndex();
       
        if (_currentSpellIndex == 3)
        {
            Alohamora();
        }  else if (_currentSpellIndex == 4)
        {
            Aparecium();
        }
    }
    
    void Alohamora()
    {
        Debug.Log("Alohamora");
    }
    
    void Aparecium()
    {
        Debug.Log("Aparecium");
    }
}