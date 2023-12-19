using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{
    private bool _isPaused;
    private bool _isWandActive;
    private bool _gameOver;
    

    [SerializeField] private InputActionReference _toggleMenuReference;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private SpellManager _spellManager;
    [SerializeField] private GameObject _restartBtn;
    [SerializeField] private GameObject _quitBtn;
    [SerializeField] private GameObject _povCam;
    
  

    void Awake()
    {
        _toggleMenuReference.action.started += ToggleMenu;
    }

    private void Start()
    {
        _isPaused = false;
        _gameOver = false;
    }

    private void Update()
    {
        _isWandActive = _spellManager.GetWandActivity();

        if (_gameOver)
        {
            PauseGame();
            _spellManager.SwitchToManipulix();
        }
        else
        {
            if (_isPaused)
            {
                PauseGame();
                _spellManager.SwitchToManipulix();
            }
            else
            {
                ResumeGame();
                transform.position = _povCam.transform.position + _povCam.transform.forward * 2f;
                transform.LookAt(_povCam.transform.position);
            }
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
        _restartBtn.SetActive(true);
        _quitBtn.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        _canvas.enabled = false;
        _restartBtn.SetActive(false);
        _quitBtn.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetGameOver()
    {
        _gameOver = true;
    }

    void ToggleMenu(InputAction.CallbackContext context)
    {
        _isPaused = !_isPaused;
    }
}

