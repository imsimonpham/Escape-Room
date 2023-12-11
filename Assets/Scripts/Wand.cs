using System;
using UnityEngine;

public class Wand : MonoBehaviour
{
    [SerializeField] private GameObject _wandSpawnPoint;
    private Renderer _renderer;
    [SerializeField] private Material _droppedWandMaterial;
    [SerializeField] private Material _pickedUpdWandMaterial;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material = _droppedWandMaterial;
    }

    void Update()
    {
        if (transform.position.y < -3)
        {
            transform.position = _wandSpawnPoint.transform.position;
        }    
    }

    public void SwapToPickedUpMat()
    {
        _renderer.material = _pickedUpdWandMaterial;
    }
    
    public void SwapToDroppedMat()
    {
        _renderer.material = _droppedWandMaterial;
    }
}
