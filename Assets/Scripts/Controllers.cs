using System;
using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

public class Controllers : MonoBehaviour
{
   [SerializeField] private Animator _animator;
   private MovableWall _wall1;
   private float _fadeDuration;
   private GameObject _wallVisualHint;
   private Light _lionStatueLight;
   private bool _lionStatueRise;
   private BoxCollider _lionStatueFloorCollider;
   private Animator _lionStatueAnim;


    /*[Header("Text Components")] 
    [SerializeField] private TMP_Text _riddle1;
    [SerializeField] private TMP_Text _riddle2;*/

    private void Start()
    {
        _wall1 = GameObject.FindWithTag("MovableWall1").GetComponent<MovableWall>();
        if (_wall1 == null)
        {
            Debug.LogError("Movable Wall 1 is null");
        }
        _wallVisualHint = GameObject.FindWithTag("WallVisualHint");
        if(_wallVisualHint == null)
        {
            Debug.LogError("Wall Visual Hint is null");
        }

        _lionStatueLight = GameObject.FindWithTag("LionStatueLight").GetComponent<Light>();
        if(_lionStatueLight == null)
        {
            Debug.LogError("Lion Statue Light is null");
        }

        _lionStatueFloorCollider = GameObject.FindWithTag("LionStatueFloor").GetComponent<BoxCollider>();
        if (_lionStatueFloorCollider == null)
        {
            Debug.LogError("Lion Statue Floor Collider is null");
        }

        _lionStatueAnim = GameObject.FindWithTag("LionStatue").GetComponent<Animator>();
        if (_lionStatueAnim == null)
        {
            Debug.LogError("Lion Statue Animator is null");
        }

        _lionStatueRise = false;
    }

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
      _wall1.SetMovableWallTrigger();
   }
   

   public void OpenCoffin()
   {
      _animator.SetTrigger("OpenCoffin");
   }

    public void RevealWallText()
    {
        _wallVisualHint.SetActive(false);
        _animator.SetTrigger("RevealText");
        StartCoroutine(LionStatueRise());
    }

    public void OpenDoor()
    {
        _animator.SetTrigger("OpenDoor");
    }

    //Lion Statue
    IEnumerator LionStatueRise()
    {
        yield return new WaitForSeconds(6f);
        _lionStatueAnim.SetTrigger("LionStatueRise");
        _lionStatueRise = true;
        _lionStatueLight.enabled = true;
    }

    public void OpenLionStatueCompartment()
    {
        _animator.SetTrigger("OpenCompartment");
    }

    public bool GetLionStatueRise()
    {
        return _lionStatueRise;
    }

    //Gargoyles
    public void OpenGargoyle()
    {
        _animator.SetTrigger("GargoyleTurn");
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
