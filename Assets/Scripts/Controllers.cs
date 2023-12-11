using System;
using UnityEngine;
using TMPro;
using System.Collections;
public class Controllers : MonoBehaviour
{
   [SerializeField] private Animator _animator;
   [SerializeField] private MovableWall _wall;
   private float _fadeDuration;
   
   /*[Header("Text Components")] 
   [SerializeField] private TMP_Text _riddle1;
   [SerializeField] private TMP_Text _riddle2;*/

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

   public void PullLeverDown()
   {
      _animator.SetTrigger("PullLever1");
      _wall.SetMovableWallTrigger();
   }
   

   public void OpenCoffin()
   {
      _animator.SetTrigger("OpenCoffin");
   }



   /*public void RevealText(TMP_Text text)
   {
      StartCoroutine(FadeInText(text));
   }
   
   IEnumerator FadeInText(TMP_Text text)
   {
      CanvasGroup canvasGroup = text.GetComponent<CanvasGroup>();

      if (canvasGroup == null)
      {
         // If CanvasGroup component is not present, add it
         canvasGroup = text.gameObject.AddComponent<CanvasGroup>();
      }

      // Ensure the alpha is initially set to 0
      canvasGroup.alpha = 0f;

      // Gradually increase the alpha to 1 over time
      while (canvasGroup.alpha < 1f)
      {
         canvasGroup.alpha += Time.deltaTime / _fadeDuration;
         yield return null;
      }

      // Ensure the final alpha is exactly 1
      canvasGroup.alpha = 1f;
   }*/
}                                                 
