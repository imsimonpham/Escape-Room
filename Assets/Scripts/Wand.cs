using UnityEngine;

public class Wand : MonoBehaviour
{
    [SerializeField] private GameObject _wandSpawnPoint;
    
    void Update()
    {
        if (transform.position.y < 0)
        {
            transform.position = _wandSpawnPoint.transform.position;
        }    
    }
}
