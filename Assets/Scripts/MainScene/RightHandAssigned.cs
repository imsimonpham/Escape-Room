using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RightHandAssigned : MonoBehaviour
{
   
    void Start()
    {
        GameObject.FindObjectOfType(typeof(RightHand)).GetComponent<RightHand>().AssignAnimator(gameObject.GetComponent<Animator>());
    }


}
