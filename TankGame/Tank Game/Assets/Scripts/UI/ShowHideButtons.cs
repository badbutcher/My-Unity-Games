using UnityEngine;

public class ShowHideButtons : MonoBehaviour
{
    public GameObject menu;
    private bool isShowing;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isShowing = !isShowing;
            menu.SetActive(isShowing);

            if (isShowing)
            {
                Cursor.visible = true;
                Time.timeScale = 0;
            }
            else
            {
                Cursor.visible = false;
                Time.timeScale = 1;
            }
        }
    }
}