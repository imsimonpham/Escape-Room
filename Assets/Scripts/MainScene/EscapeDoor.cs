using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeDoor : MonoBehaviour
{
    [SerializeField] private GameObject _compass;
    [SerializeField] private BoxCollider _collider;
    [SerializeField] private Material _compassActiveMaterial;
    [SerializeField] private Material _compassInactiveMaterial;

    private Renderer _compassRenderer;
    private Renderer _needleRenderer;

    private void Start()
    {
        _compassRenderer = _compass.GetComponent<Renderer>();
        _needleRenderer = _compass.transform.GetChild(0).GetComponent<Renderer>();
    }

    private void Update()
    {
        if (IsCompassNearBy())
        {
            SetActiveMaterial();
        } else
        {
            SetInactiveMaterial();
        }
    }

    bool IsCompassNearBy()
    {
        Bounds doorBounds = _collider.bounds;
        bool isCompassNearBy = doorBounds.Contains(_compass.transform.position);
        return isCompassNearBy;
    }

    void SetActiveMaterial()
    {
        _compassRenderer.material = _compassActiveMaterial;
        _needleRenderer.material = _compassActiveMaterial;
    }

    void SetInactiveMaterial()
    {
        _compassRenderer.material = _compassInactiveMaterial;
        _needleRenderer.material = _compassInactiveMaterial;
    }
}
