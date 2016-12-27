using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EyeStats : MonoBehaviour
{
    private int eyeMinDmg = 0;
    private int eyeMaxDmg = 0;
    public int EyeDmg = 0;

    public float EyeHp = 0;
    public float GiveExp = 0;

    private float currentStage = 0;

    private Text textHp;

    private void Start()
    {
        this.textHp = GameObject.Find("EnemyTextHp").GetComponent<Text>();
        this.currentStage = SceneManager.GetActiveScene().buildIndex;
        if (this.currentStage >= 1 && this.currentStage <= 3)
        {
            this.EyeHp = 15;
            this.eyeMinDmg = 2;
            this.eyeMaxDmg = 4;
            this.GiveExp = 10;
        }

        if (this.currentStage >= 4 && this.currentStage <= 6)
        {
            this.EyeHp = 20;
            this.eyeMinDmg = 2;
            this.eyeMaxDmg = 5;
            this.GiveExp = 20;
        }

        if (this.currentStage >= 7 && this.currentStage <= 9)
        {
            this.EyeHp = 30;
            this.eyeMinDmg = 4;
            this.eyeMaxDmg = 4;
            this.GiveExp = 30;
        }
    }

    private void Update()
    {
        this.textHp.text = this.EyeHp.ToString();
        this.EyeDmg = Random.Range(this.eyeMinDmg, this.eyeMaxDmg + 1);
        if (this.EyeHp <= 0)
        {
            this.textHp.text = string.Empty;
            PlayerMoveScript.EnemyFound = false;
            MonoBehaviour.Destroy(this.gameObject);
        }
    }
}