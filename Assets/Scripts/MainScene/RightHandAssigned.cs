using Unity.VisualScripting;
using UnityEngine;

public class RightHandAssigned : MonoBehaviour
{
    
    void Start()
    {
        GameObject.FindObjectOfType(typeof(RightHand)).GetComponent<RightHand>().AssignAnimator(gameObject.GetComponent<Animator>());
    }
    
}
