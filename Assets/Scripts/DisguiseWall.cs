using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisguiseWall : MonoBehaviour
{
    [SerializeField] private GameObject _doorFrame;
    [SerializeField] private BoxCollider _collider;
    [SerializeField] private GameObject _compass;

    private void Update()
    {
        if (IsCompassNearBy())
        {
            _doorFrame.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    bool IsCompassNearBy()
    {
        Bounds doorBounds = _collider.bounds;
        bool isCompassNearBy = doorBounds.Contains(_compass.transform.position);
        return isCompassNearBy;
    }
}
