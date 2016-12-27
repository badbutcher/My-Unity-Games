using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UglyHydraStats : MonoBehaviour
{
    private int uglyHydraMinDmg = 0;
    private int uglyHydraMaxDmg = 0;
    public int UglyHydraDmg = 0;

    public float UglyHydraHp = 0;
    public float GiveExp = 0;

    private float currentStage = 0;

    private Text textHp;

    private void Start()
    {
        this.textHp = GameObject.Find("EnemyTextHp").GetComponent<Text>();
        this.currentStage = SceneManager.GetActiveScene().buildIndex;
        if (this.currentStage == 10)
        {
            this.UglyHydraHp = 250;
            this.uglyHydraMinDmg = 7;
            this.uglyHydraMaxDmg = 10;
            this.GiveExp = 200;
        }
    }

    private void Update()
    {
        this.textHp.text = this.UglyHydraHp.ToString();
        this.UglyHydraDmg = Random.Range(this.uglyHydraMinDmg, this.uglyHydraMaxDmg + 1);
        if (this.UglyHydraHp <= 0)
        {
            this.textHp.text = string.Empty;
            PlayerMoveScript.EnemyFound = false;
            MonoBehaviour.Destroy(this.gameObject);
        }
    }
}
