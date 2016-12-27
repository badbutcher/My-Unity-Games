using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Spells : MonoBehaviour
{
    public static bool PowerAttack;
    public static bool LifeStealReady;

    private GameObject powerAttackLock;
    private GameObject lifeStealLock;

    private GameObject healReady;

    private Text powerAttackText;
    private Text lifeStealText;

    private AudioSource audioSource;
    public AudioClip HealSound;
    public AudioClip PowerAttackSound;
    public AudioClip LifeStealSound;

    private void Awake()
    {
        this.audioSource = this.GetComponent<AudioSource>();
        this.healReady = GameObject.Find("HealReady");
        this.powerAttackLock = GameObject.Find("PowerAttackLock");
        this.lifeStealLock = GameObject.Find("LifeStealLock");
        this.powerAttackText = GameObject.Find("PowerAttackText").GetComponent<Text>();
        this.lifeStealText = GameObject.Find("LifeStealText").GetComponent<Text>();
    }

    private void Start()
    {
        this.powerAttackText.text = "Need lvl 2 Intelligence to unlock";
        this.lifeStealText.text = "Need lvl 4 Intelligence to unlock";
        this.gameObject.SetActive(false);
        this.healReady.SetActive(false);
    }

    private void Update()
    {
        if (ManaSlider.points >= 2)
        {
            this.powerAttackLock.SetActive(false);
            this.powerAttackText.text = "Cost 40 - Your next attack deals 15 extra dmg";
        }

        if (ManaSlider.points >= 4)
        {
            this.lifeStealLock.SetActive(false);
            this.lifeStealText.text = "Cost 30 - Your next attack deals 10 extra dmg and heals for 5 hp";
        }
    }

    public void Heal()
    {
        if (PlayerMoveScript.PlayerMana >= 20 && PlayerMoveScript.PlayerHp < PlayerMoveScript.PlayerMaxHp)
        {
            this.audioSource.PlayOneShot(this.HealSound);
            this.StartCoroutine(this.HealOn());
            PlayerMoveScript.PlayerHp += 20;
            if (PlayerMoveScript.PlayerHp >= PlayerMoveScript.PlayerMaxHp)
            {
                PlayerMoveScript.PlayerHp = PlayerMoveScript.PlayerMaxHp;
            }

            PlayerMoveScript.PlayerMana -= 20;
        }
    }

    public void FireBow()
    {
        if (PlayerMoveScript.EnemyFound && PlayerMoveScript.PlayerMana >= 40 && !PowerAttack)
        {
            this.audioSource.PlayOneShot(this.PowerAttackSound);
            PowerAttack = true;
            PlayerMoveScript.PlayerMana -= 30;
        }
    }

    public void LifeSteal()
    {
        if (PlayerMoveScript.EnemyFound && PlayerMoveScript.PlayerMana >= 30 && !LifeStealReady)
        {
            this.audioSource.PlayOneShot(this.LifeStealSound);
            LifeStealReady = true;
            PlayerMoveScript.PlayerMana -= 30;
        }
    }

    public IEnumerator HealOn()
    {
        this.healReady.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        this.healReady.SetActive(false);
    }
}