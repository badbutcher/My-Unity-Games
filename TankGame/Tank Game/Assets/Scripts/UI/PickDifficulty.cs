using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PickDifficulty : MonoBehaviour
{
    public void ButtonClicked(Button click)
    {
        if (click.CompareTag("Easy"))
        {
            CoinRotator.change = false;
            Time.timeScale = 1;
            MoneyManager.Score = 0;
            MoneyManager.Coins = 0;

            PlayerHealth.Health = 300;
            PlayerHealth.DamageFromTurret = 10;
            PlayerHealth.DamageFromEnemyTank = 20;
            MoveScript.moveSpeed = 35;
            MoveScript.rotateSpeed = 35;
            ShotShell.fireRate = 1.5f;

            TurretHealth.DamageFromPlayer = 300;

            EnemyTankHealth.EnemyTankDamageFromPlayer = 200;

            SceneManager.LoadScene("Game");
        }

        if (click.CompareTag("Normal"))
        {
            CoinRotator.change = false;
            Time.timeScale = 1;
            MoneyManager.Score = 0;
            MoneyManager.Coins = 0;

            Time.timeScale = 1;
            MoneyManager.Score = 0;
            MoneyManager.Coins = 0;

            PlayerHealth.Health = 200;
            PlayerHealth.DamageFromTurret = 20;
            PlayerHealth.DamageFromEnemyTank = 30;
            MoveScript.moveSpeed = 30;
            MoveScript.rotateSpeed = 30;
            ShotShell.fireRate = 1.5f;

            TurretHealth.DamageFromPlayer = 200;

            EnemyTankHealth.EnemyTankDamageFromPlayer = 150;

            SceneManager.LoadScene("Game");
        }

        if (click.CompareTag("Hard"))
        {
            CoinRotator.change = false;
            Time.timeScale = 1;
            MoneyManager.Score = 0;
            MoneyManager.Coins = 0;

            PlayerHealth.Health = 200;
            PlayerHealth.DamageFromTurret = 30;
            PlayerHealth.DamageFromEnemyTank = 50;
            MoveScript.moveSpeed = 25;
            MoveScript.rotateSpeed = 25;
            ShotShell.fireRate = 1.5f;

            TurretHealth.DamageFromPlayer = 100;

            EnemyTankHealth.EnemyTankDamageFromPlayer = 100;

            SceneManager.LoadScene("Game");
        }
    }
}