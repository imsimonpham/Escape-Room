using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RightHand : MonoBehaviour
{
   [SerializeField] private XRDirectInteractor _xrDirectInteractor;
   [SerializeField] private Animator _animator;
   [SerializeField] private XRInteractorLineVisual _lineVisual;
   
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
        }
        else
        {
            _animator.SetBool("HoldingWand", false);
            _lineVisual.enabled = false;
        }
    }

    public void AssignAnimator(Animator anim)
    {
        _animator = anim;
    }

}