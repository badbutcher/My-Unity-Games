using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static float Health = 200;
    public static float DamageFromTurret = 20;
    public static float DamageFromEnemyTank = 25;
    public AudioClip GetDestoyedSound;
    public Slider PlayerHealthBar;
    public Text HealthNumber;
    public static bool IsEndless = false;
    public GameObject YouAreDeadText;

    private float lives = 1;
    private float HighScore = 0;
    private bool playerDead;

    void Update()
    {
        HealthNumber.text = "" + Health;
        if (Health <= 0)
        {
            if (!playerDead)
            {
                PlayerDying();
            }
        }

        if (Health > PlayerHealthBar.value)
        {
            PlayerHealthBar.maxValue = Health;
        }

        PlayerHealthBar.value = Health;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "TurretShot")
        {
            PlayerHealthBar.value = Health;
            Health -= DamageFromTurret / 2;
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "EnemyTankShell")
        {
            PlayerHealthBar.value = Health;
            Health -= DamageFromEnemyTank;
            Destroy(col.gameObject);
        }
    }

    void PlayerDying()
    {
        playerDead = true;
        if (!IsEndless)
        {
            lives--;
            if (lives > 0)
            {
                this.transform.position = new Vector3(-127, 10, -381);
            }
            else
            {
                YouAreDeadText.SetActive(true);
                Time.timeScale = 0;
            }
        }
        else
        {
            if (MoneyManager.Score > HighScore)
            {
                PlayerPrefs.SetFloat("highScore", MoneyManager.Score);
            }

            Destroy(gameObject);
        }

        MoneyManager.Score = 0;
        MoneyManager.Coins = 0;
        AudioSource.PlayClipAtPoint(GetDestoyedSound, Camera.main.transform.position, 0.3f);
        Health = HealthSlider.BonusHp + 200;
        playerDead = false;
    }
}