using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WallDetection : MonoBehaviour
{
    [SerializeField] private XRRayInteractor _teleportRay;
    [SerializeField] private GameObject _debugLight;
    [SerializeField] private GameObject[] _floors;

    private void Update()
    {
        WallDetector();
    }

    void WallDetector()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitData;
        if (Physics.Raycast(ray, out hitData))
        {
            GameObject hitObject = hitData.transform.gameObject;
            Debug.DrawRay(ray.origin, ray.direction * 2f, Color.red);
            float distance = hitData.distance;
            Debug.Log(distance);
            if ((hitObject.CompareTag("Wall") || hitObject.CompareTag("MovableWall1") || hitObject.CompareTag("MovableWall2")) && distance <= 1f)
            {
                DisableTeleportationAread();
                //_debugLight.SetActive(true);

            } else
            {
                EnableTeleportationAread();
                //_debugLight.SetActive(false);
            }
        }
    }

    void DisableTeleportationAread()
    {
        foreach(GameObject floor in _floors)
        {
            TeleportationArea area = floor.GetComponent<TeleportationArea>();
            area.enabled = false;
        }
    }

    void EnableTeleportationAread()
    {
        foreach (GameObject floor in _floors)
        {
            TeleportationArea area = floor.GetComponent<TeleportationArea>();
            area.enabled = true;
        }
    }

}
