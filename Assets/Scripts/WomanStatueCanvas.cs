using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WomanStatueCanvas : MonoBehaviour
{
    [SerializeField] private Image _bg;
    [SerializeField] private TMP_Text _hint1;
    [SerializeField] private TMP_Text _hint2;

    private void Start()
    {
        
    }

    public void ShowHint1()
    {
        _bg.gameObject.SetActive(true);
        _hint2.gameObject.SetActive(false);
        _hint1.gameObject.SetActive(true);
    }

    public void ShowHint2()
    {
        _hint1.gameObject.SetActive(false);
        _hint2.gameObject.SetActive(true);
    }

    public void HideHints()
    {
        _bg.gameObject?.SetActive(false);
        _hint1.gameObject.SetActive(false);
        _hint2.gameObject.SetActive(false);
    }
}
