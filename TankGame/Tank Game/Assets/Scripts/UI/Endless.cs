using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Endless : MonoBehaviour
{
    public Button click;

    void Update()
    {
        if (CoinRotator.change)
        {
            click.interactable = true;
        }
    }

    public void ButtonClicked()
    {
        if (click.CompareTag("Endless"))
        {
            PlayerHealth.IsEndless = true;
            Time.timeScale = 1;
            MoneyManager.Score = 0;
            MoneyManager.Coins = 0;

            Time.timeScale = 1;
            MoneyManager.Score = 0;
            MoneyManager.Coins = 0;

            PlayerHealth.Health = 500;
            PlayerHealth.DamageFromTurret = 20;
            PlayerHealth.DamageFromEnemyTank = 30;
            MoveScript.moveSpeed = 30;
            MoveScript.rotateSpeed = 30;
            ShotShell.fireRate = 1.5f;

            TurretHealth.DamageFromPlayer = 200;

            EnemyTankHealth.EnemyTankDamageFromPlayer = 150;

            SceneManager.LoadScene("Endless");
        }
    }
}