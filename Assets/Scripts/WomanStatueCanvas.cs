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
    private bool _nextHint;
    private bool _previousHint;

    private void Start()
    {
        _nextHint = false;
        _previousHint = true;
    }

    public void ShowHint()
    {
        if(_nextHint)
        {
            _bg.gameObject.SetActive(true);
            _hint1.gameObject.SetActive(false);
            _hint2.gameObject.SetActive(true);
        } else if(_previousHint)
        {
            _bg.gameObject.SetActive(true);
            _hint2.gameObject.SetActive(false);
            _hint1.gameObject.SetActive(true);
        }
    }

    public void Next()
    {
        _nextHint = true;
        _previousHint = false;
    }

    public void Previous()
    {
        _previousHint = true;
        _nextHint = false;
    }

    public void HideHints()
    {
        _bg.gameObject?.SetActive(false);
        _hint1.gameObject.SetActive(false);
        _hint2.gameObject.SetActive(false);
    }
}
