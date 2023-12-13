using UnityEngine;

public class LionStatueFloor : MonoBehaviour
{
    [SerializeField] private Camera _mainCam;
    private Vector3 _boxCenter;
    [SerializeField] private Vector3 _boxSize;
    [SerializeField] private Controllers _lionStatue;
    BoxCollider _floorCollider;


    private void Start()
    {
        _boxCenter = transform.position;
        _floorCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (_lionStatue.transform.position.y > 0.598)
        {
            _floorCollider.enabled = true;
        } else
        {
            ScanForMainCam();
        }
    }

    void ScanForMainCam()
    {
        Bounds boxBounds = new Bounds(_boxCenter, _boxSize);
        bool isMainCamInBox = boxBounds.Contains(_mainCam.transform.position);

        if (isMainCamInBox)
        {
            _floorCollider.enabled = true;
        }
        else
        {
            _floorCollider.enabled = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_boxCenter, _boxSize);
    }
}
