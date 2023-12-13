using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    [SerializeField] private GameObject _skull;
    [SerializeField] private GameObject _crystal;
    [SerializeField] private GameObject _crown;

    [SerializeField] private GameObject _liquid;
    [SerializeField] private GameObject _compass;
    

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

        // Return true if all three items are inside the pot
        return isSkullInPot && isCrystalInPot && isCrownInPot;
    }

    private void ForgeCompass()
    {
        _skull.SetActive(false);
        _crystal.SetActive(false);
        _crown.SetActive(false);
        _liquid.SetActive(false);
        _compass.SetActive(true);
    }
}
