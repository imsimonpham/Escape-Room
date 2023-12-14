using UnityEngine;

public class LionStatueFloor : MonoBehaviour
{
    [SerializeField] private Camera _povCam;
    private Vector3 _boxCenter;
    [SerializeField] private Vector3 _boxSize;
    [SerializeField] private Controllers _lionStatue;
    BoxCollider _floorCollider;


    private void Start()
    {
        _floorCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (_lionStatue.transform.position.y > 0.598)
        {
            _floorCollider.enabled = true;
        } else
        {
            ScanForPOVCam();
        }
    }

    void ScanForPOVCam()
    {
        Bounds boxBounds = new Bounds(_boxCenter, _boxSize);
        bool isMainCamInBox = boxBounds.Contains(_povCam.transform.position);

        if (isMainCamInBox)
        {
            _floorCollider.enabled = true;
        }
        else
        {
            _floorCollider.enabled = false;
        }
    }
}
