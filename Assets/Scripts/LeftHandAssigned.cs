using Unity.VisualScripting;
using UnityEngine;

public class LeftHandAssigned : MonoBehaviour
{
    
    void Start()
    {
        GameObject.FindObjectOfType(typeof(LeftHand)).GetComponent<LeftHand>().AssignAnimator(gameObject.GetComponent<Animator>());
    }
    
}