using UnityEngine;

public class ExitStatusScreen : MonoBehaviour
{
    private Canvas screen;

    private void Awake()
    {
        this.screen = GameObject.Find("SkillMenu").GetComponent<Canvas>();
    }

    public void GoBack()
    {
        this.screen.GetComponent<Canvas>().enabled = false;
    }
}