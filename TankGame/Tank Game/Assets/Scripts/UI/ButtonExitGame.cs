using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonExitGame : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}