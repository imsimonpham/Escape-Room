using System.Collections;
using UnityEngine;

public class Pot : MonoBehaviour
{
    [SerializeField] private GameObject _skull;
    [SerializeField] private GameObject _crystal;
    [SerializeField] private GameObject _crown;

    [SerializeField] private GameObject _liquid;
    [SerializeField] private GameObject _compass;
    [SerializeField] private GameObject _smoke;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _forgeSound;

    private BoxCollider _potCollider;

    private void Start()
    {
        _potCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        bool areItemsInPot = CheckItemsInPot();

        if (areItemsInPot)
        {
            _smoke.SetActive(true);
            ForgeCompass();
        }
    }

    bool CheckItemsInPot()
    {
        // Calculate the bounds of the pot
        Bounds potBounds = _potCollider.bounds;

        // Check if all three items are within the pot's bounds
        bool isSkullInPot = potBounds.Contains(_skull.transform.position);
        bool isCrystalInPot = potBounds.Contains(_crystal.transform.position);
        bool isCrownInPot = potBounds.Contains(_crown.transform.position);

        return isSkullInPot && isCrystalInPot && isCrownInPot;
    }

    private void ForgeCompass()
    {
        _skull.SetActive(false);
        _crystal.SetActive(false);
        _crown.SetActive(false);
        _liquid.SetActive(false);
        //_audioSource.PlayOneShot(_forgeSound);
        _compass.SetActive(true);
    }
}
