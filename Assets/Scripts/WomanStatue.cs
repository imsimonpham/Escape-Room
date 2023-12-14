using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanStatue : MonoBehaviour
{
    [SerializeField] private Camera _povCam;
    [SerializeField] private BoxCollider _boxCollider;
    [SerializeField] private WomanStatueCanvas _canvas;

    // Update is called once per frame
    void Update()
    {
        if (CheckForPOVCam())
        {
            _canvas.ShowHint1();
            _canvas.Invoke("ShowHint2", 18f);
        } else
        {
            _canvas.HideHints();
        }
    }

    bool CheckForPOVCam()
    {
        Bounds statueBounds = _boxCollider.bounds;
        bool isPlayerNearBy = statueBounds.Contains(_povCam.transform.position);
        return isPlayerNearBy;
    }
}
