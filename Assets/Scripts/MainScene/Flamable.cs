using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamable : MonoBehaviour
{
    [SerializeField] private GameObject[] _particleSystems;
    [SerializeField] private GameObject _pointLight;


    public void LightUpCandles()
    {
        foreach (GameObject particleSystem in _particleSystems)
        {
            particleSystem.SetActive(true);
        }
        _pointLight.SetActive(true);
    }
    
    public void LightUpFirepit()
    {
        _particleSystems[0].SetActive(true);
        _pointLight.SetActive(true);
    }
}
