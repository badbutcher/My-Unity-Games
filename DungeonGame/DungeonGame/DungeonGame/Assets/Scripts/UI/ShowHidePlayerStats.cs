using UnityEngine;

public class ShowHidePlayerStats : MonoBehaviour
{
    private GameObject menuStatusScreen;

    private void Awake()
    {
        this.menuStatusScreen = GameObject.Find("PlayerStatsMenu");
    }

    public void ShowPlayerStatsMenu()
    {
        this.menuStatusScreen.SetActive(true);
    }

    public void HidePlayerStatsMenu()
    {
        this.menuStatusScreen.SetActive(false);
    }
}