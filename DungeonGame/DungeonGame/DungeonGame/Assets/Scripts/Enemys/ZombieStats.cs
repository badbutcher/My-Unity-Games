using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ZombieStats : MonoBehaviour
{
    private int zombieMinDmg = 0;
    private int zombieMaxDmg = 0;
    public int ZombieDmg = 0;

    public float ZombieHp = 0;
    public float GiveExp = 0;

    private float currentStage = 0;

    private Text textHp;

    private void Start()
    {
        this.textHp = GameObject.Find("EnemyTextHp").GetComponent<Text>();
        this.currentStage = SceneManager.GetActiveScene().buildIndex;
        if (this.currentStage >= 1 && this.currentStage <= 6)
        {
            this.ZombieHp = 35;
            this.zombieMinDmg = 2;
            this.zombieMaxDmg = 3;
            this.GiveExp = 25;
        }

        if (this.currentStage >= 7 && this.currentStage <= 9)
        {
            this.ZombieHp = 55;
            this.zombieMinDmg = 4;
            this.zombieMaxDmg = 5;
            this.GiveExp = 30;
        }
    }

    private void Update()
    {
        this.textHp.text = this.ZombieHp.ToString();
        this.ZombieDmg = Random.Range(this.zombieMinDmg, this.zombieMaxDmg + 1);
        if (this.ZombieHp <= 0)
        {
            this.textHp.text = string.Empty;
            PlayerMoveScript.EnemyFound = false;
            MonoBehaviour.Destroy(this.gameObject);
        }
    }
}