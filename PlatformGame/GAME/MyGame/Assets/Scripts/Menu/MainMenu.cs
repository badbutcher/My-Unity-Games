using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public Canvas Stages;

    public void ShowStages()
    {
        Stages.sortingOrder = 1;
    }

    public void StopSound()
    {
        if (AudioListener.volume != 0)
        {
            AudioListener.volume = 0;
        }
        else if (AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
