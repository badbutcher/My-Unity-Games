using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public Canvas StagesCanvas;
    public static bool ShowStages;

    void Start()
    {
        Cursor.visible = true;
        if (ShowStages)
        {
            this.StagesCanvas.sortingOrder = 1;
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void ShowStagesButton()
    {
        this.StagesCanvas.sortingOrder = 1;
        ShowStages = true;
    }

    public void Exit()
    {
        Application.Quit();
    }
}