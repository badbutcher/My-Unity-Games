using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UiButtons : MonoBehaviour
{
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
