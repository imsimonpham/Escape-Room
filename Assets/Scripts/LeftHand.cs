using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LeftHand : MonoBehaviour
{
    [SerializeField] private XRDirectInteractor _xrDirectInteractor;
    [SerializeField] private Animator _animator;
   
    void Update()
    {
        if (_animator != null)
        {
            CheckForObject();
        }
    }

    public void CheckForObject()
    {
        var interactables = _xrDirectInteractor.interactablesSelected;
        
        if (interactables != null && interactables.Count > 0)
        {
            _animator.SetBool("HoldingObject", true);
        }
        else
        {
            _animator.SetBool("HoldingObject", false);
        }
    }

    public void AssignAnimator(Animator anim)
    {
        _animator = anim;
    }

}