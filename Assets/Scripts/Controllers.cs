using UnityEngine;

public class Controllers : MonoBehaviour
{
   [SerializeField] private Animator _animator;

   public void ToggleSwitch()
   {
      bool currentSwitchState = _animator.GetBool("SwitchOn");
      _animator.SetBool("SwitchOn", !currentSwitchState);
   }
   
   public void ToggleLever()
   {
      bool currentLeverState = _animator.GetBool("LeverOn");
      _animator.SetBool("LeverOn", !currentLeverState);
   }
}                                                 
