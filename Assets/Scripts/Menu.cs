using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{
    private bool _isPaused;  

    [Header("For Menu Scene Only")]
    [SerializeField] private GameObject _instructionCanvas;

    [Header("For Main Scene Only")]
    [SerializeField] private InputActionReference _toggleMenuReference;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private SpellManager _spellManager;

    void Awake()
    {
        _toggleMenuReference.action.started += ToggleMenu;
    }

    private void Start()
    {
        _isPaused = false;
    }

    private void Update()
    {
        if(_isPaused)
        {
            PauseGame();
            _spellManager.SwitchToManipulix();
        } else
        {
            ResumeGame();
        }
    }


    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        _canvas.enabled = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        _canvas.enabled = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowInstruction()
    {
        _instructionCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    void ToggleMenu(InputAction.CallbackContext context)
    {
        _isPaused = !_isPaused;
    }
}

