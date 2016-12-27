using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkeletonStats : MonoBehaviour
{
    private int skeletonMinDmg = 0;
    private int skeletonMaxDmg = 0;
    public int SkeletonDmg = 0;

    public float SkeletonHp = 0;
    public float GiveExp = 0;

    private float currentStage = 0;

    private Text textHp;

    private void Start()
    {
        this.textHp = GameObject.Find("EnemyTextHp").GetComponent<Text>();
        this.currentStage = SceneManager.GetActiveScene().buildIndex;
        if (this.currentStage >= 1 && this.currentStage <= 4)
        {
            this.SkeletonHp = 35;
            this.skeletonMinDmg = 2;
            this.skeletonMaxDmg = 4;
            this.GiveExp = 25;
        }

        if (this.currentStage == 5)
        {
            this.SkeletonHp = 75;
            this.skeletonMinDmg = 4;
            this.skeletonMaxDmg = 5;
            this.GiveExp = 100;
        }

        if (this.currentStage >= 6 && this.currentStage <= 9)
        {
            this.SkeletonHp = 50;
            this.skeletonMinDmg = 4;
            this.skeletonMaxDmg = 4;
            this.GiveExp = 35;
        }
    }

    private void Update()
    {
        this.textHp.text = this.SkeletonHp.ToString();
        this.SkeletonDmg = Random.Range(this.skeletonMinDmg, this.skeletonMaxDmg + 1);
        if (this.SkeletonHp <= 0)
        {
            this.textHp.text = string.Empty;
            PlayerMoveScript.EnemyFound = false;
            MonoBehaviour.Destroy(this.gameObject);
        }
    }
}