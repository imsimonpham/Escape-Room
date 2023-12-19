using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _spawnPoint;
    [SerializeField] private GameObject _camOffset;
    [SerializeField] private GameObject _menuCanvas;
    [SerializeField] private LeftHandAssigned _leftHandAssigned;
    [SerializeField] private RightHandAssigned _rightHandAssgined;
    [SerializeField] private InputActionReference _useSpellReference;

    void Awake()
    {
        _useSpellReference.action.started += UseSpell;
    }
    

    void Update()
    {
        _camOffset.transform.position = _spawnPoint.transform.position;
        _camOffset.transform.LookAt(_menuCanvas.transform);
    }

    void UseSpell(InputAction.CallbackContext context){}
}
