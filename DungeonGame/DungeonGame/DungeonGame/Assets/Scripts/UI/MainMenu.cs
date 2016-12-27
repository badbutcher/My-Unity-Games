using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static float stageSixUnlocked;
    public GameObject continueOne;
    public GameObject InfoMenu;

    public void Start()
    {
        ResetGame();
        PlayerPrefs.GetFloat("Unlocked");
        if (PlayerPrefs.GetFloat("Unlocked") == 1)
        {
            this.continueOne.SetActive(true);
        }
        else
        {
            this.continueOne.SetActive(false);
        }
    }

    private void ResetGame()
    {
        Shop.ShieldLevel = 1;
        Shop.SwordLevel = 1;
        PlayerMoveScript.EnemyFound = false;
        PlayerMoveScript.PlayerExp = 0;
        PlayerMoveScript.PlayerGold = 0;
        PlayerMoveScript.PlayerHealthPosts = 1;
        PlayerMoveScript.PlayerHp = 100;
        PlayerMoveScript.PlayerLevel = 1;
        PlayerMoveScript.PlayerMana = 100;
        PlayerMoveScript.PlayerManaPosts = 0;
        PlayerMoveScript.PlayerMaxDmg = 3;
        PlayerMoveScript.PlayerMaxExp = 10;
        PlayerMoveScript.PlayerMaxHp = 100;
        PlayerMoveScript.PlayerMaxMana = 100;
        PlayerMoveScript.PlayerMinDmg = 1;
        PlayerMoveScript.PlayerSuperPosts = 0;
        PlayerMoveScript.SkillPoints = 0;
        PlayerMoveScript.Turns = 0;
        AttackSlider.points = 0;
        HealthSlider.points = 0;
        ManaSlider.points = 0;
             
    }

    public void StartGame()
    {
        ResetGame();
        SceneManager.LoadScene("Stage 1");
    }

    public void ContinueGame()
    {
        ResetGame();
        PlayerMoveScript.PlayerExp += 210;
        PlayerMoveScript.PlayerGold += 150;
        SceneManager.LoadScene("Stage 6");
    }

    public void ShowInfoMenu()
    {
        this.InfoMenu.SetActive(true);
    }

    public void HideInfoMenu()
    {
        this.InfoMenu.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
