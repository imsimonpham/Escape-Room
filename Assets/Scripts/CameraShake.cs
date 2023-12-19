using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private CinemachineImpulseSource _impulse;

    void Start()
    {
        
    }

    public void ShakeCamera()
    {
        _impulse.GenerateImpulse();
    }
}
