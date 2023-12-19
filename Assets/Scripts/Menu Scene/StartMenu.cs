using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class StartMenu : MonoBehaviour
{
 
    [Header("For Menu Scene Only")]
    [SerializeField] private GameObject _instructionCanvas;


    public void StartGame()
    {
        SceneManager.LoadScene("Main");
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
}

