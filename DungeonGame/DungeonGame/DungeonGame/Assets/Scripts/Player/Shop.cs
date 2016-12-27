using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private GameObject levelOneSword;
    private GameObject levelTwoSword;
    private GameObject levelThreeSword;
    private GameObject levelOneShield;
    private GameObject levelTwoShield;
    private GameObject levelThreeShield;

    private GameObject swordTwoButton;
    private GameObject swordThreeButton;
    private GameObject shieldTwoButton;
    private GameObject shieldThreeButton;

    private GameObject swordTwoLock;
    private GameObject swordThreeLock;
    private GameObject shieldTwoLock;
    private GameObject shieldThreeLock;

    private Text playerGold;

    private static bool swordTwo;
    private static bool swordThree;
    private static bool shieldTwo;
    private static bool shieldThree;

    public static float SwordLevel = 1;
    public static float ShieldLevel = 1;

    private AudioSource audioSource;
    public AudioClip BuyItemSound;

    private void Awake()
    {
        this.audioSource = this.GetComponent<AudioSource>();
        this.gameObject.SetActive(true);
        this.levelOneSword = GameObject.Find("SwordLVL1");
        this.levelTwoSword = GameObject.Find("SwordLVL2");
        this.levelThreeSword = GameObject.Find("SwordLVL3");
        this.levelOneShield = GameObject.Find("ShieldLVL1");
        this.levelTwoShield = GameObject.Find("ShieldLVL2");
        this.levelThreeShield = GameObject.Find("ShieldLVL3");

        this.swordTwoButton = GameObject.Find("SwordTwo");
        this.swordThreeButton = GameObject.Find("SwordThree");
        this.shieldTwoButton = GameObject.Find("ShieldTwo");
        this.shieldThreeButton = GameObject.Find("ShieldThree");

        this.swordTwoLock = GameObject.Find("SwordTwoLock");
        this.swordThreeLock = GameObject.Find("SwordThreeLock");
        this.shieldTwoLock = GameObject.Find("ShieldTwoLock");
        this.shieldThreeLock = GameObject.Find("ShieldThreeLock");

        this.playerGold = GameObject.Find("MyGold").GetComponent<Text>();
    }

    private void Start()
    {
        if (SwordLevel == 2)
        {
            swordTwoButton.SetActive(false);
        }
        else if (SwordLevel == 3)
        {
            swordTwoButton.SetActive(false);
            swordThreeButton.SetActive(false);
        }

        if (ShieldLevel == 2)
        {
            shieldTwoButton.SetActive(false);
        }
        else if (ShieldLevel == 3)
        {
            shieldTwoButton.SetActive(false);
            shieldThreeButton.SetActive(false);
        }

        if (!swordTwo && !swordThree)
        {
            this.levelOneSword.SetActive(true);
            this.levelTwoSword.SetActive(false);
            this.levelThreeSword.SetActive(false);
        }
        else if (swordTwo && !swordThree)
        {
            this.levelOneSword.SetActive(false);
            this.levelTwoSword.SetActive(true);
            this.levelThreeSword.SetActive(false);
        }
        else if (!swordTwo && swordThree)
        {
            this.levelOneSword.SetActive(false);
            this.levelTwoSword.SetActive(false);
            this.levelThreeSword.SetActive(true);
        }

        if (!shieldTwo && !shieldThree)
        {
            this.levelOneShield.SetActive(true);
            this.levelTwoShield.SetActive(false);
            this.levelThreeShield.SetActive(false);
        }
        else if (shieldTwo && !shieldThree)
        {
            this.levelOneShield.SetActive(false);
            this.levelTwoShield.SetActive(true);
            this.levelThreeShield.SetActive(false);
        }
        else if (!shieldTwo && shieldThree)
        {
            this.levelOneShield.SetActive(false);
            this.levelTwoShield.SetActive(false);
            this.levelThreeShield.SetActive(true);
        }

        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        this.playerGold.text = "My gold" + PlayerMoveScript.PlayerGold;

        if (AttackSlider.points >= 2)
        {
            this.swordTwoLock.SetActive(false);
        }

        if (AttackSlider.points >= 4)
        {
            this.swordThreeLock.SetActive(false);
        }

        if (HealthSlider.points >= 2)
        {
            this.shieldTwoLock.SetActive(false);
        }

        if (HealthSlider.points >= 4)
        {
            this.shieldThreeLock.SetActive(false);
        }
    }

    public void BuyHealthPot()
    {
        if (PlayerMoveScript.PlayerGold >= 50)
        {
            this.audioSource.PlayOneShot(this.BuyItemSound);
            PlayerMoveScript.PlayerGold -= 50;
            PlayerMoveScript.PlayerHealthPosts++;
        }
    }

    public void BuyManaPot()
    {
        if (PlayerMoveScript.PlayerGold >= 50)
        {
            this.audioSource.PlayOneShot(this.BuyItemSound);
            PlayerMoveScript.PlayerGold -= 50;
            PlayerMoveScript.PlayerManaPosts++;
        }
    }

    public void UpdateSwordTwo()
    {
        if (PlayerMoveScript.PlayerGold >= 100 && AttackSlider.points >= 2)
        {
            this.audioSource.PlayOneShot(this.BuyItemSound);
            PlayerMoveScript.PlayerGold -= 100;
            this.levelOneSword.SetActive(false);
            this.levelTwoSword.SetActive(true);
            PlayerMoveScript.PlayerMinDmg++;
            PlayerMoveScript.PlayerMaxDmg++;
            swordTwo = true;
            swordThree = false;
            this.swordTwoButton.SetActive(false);
            SwordLevel++;
        }
    }

    public void UpdateSwordThree()
    {
        if (PlayerMoveScript.PlayerGold >= 200 && AttackSlider.points >= 4)
        {
            this.audioSource.PlayOneShot(this.BuyItemSound);
            PlayerMoveScript.PlayerGold -= 200;
            this.levelTwoSword.SetActive(false);
            this.levelThreeSword.SetActive(true);
            PlayerMoveScript.PlayerMinDmg++;
            PlayerMoveScript.PlayerMaxDmg++;
            swordTwo = false;
            swordThree = true;
            this.swordThreeButton.SetActive(false);
            SwordLevel++;
        }
    }

    public void UpdateSheldTwo()
    {
        if (PlayerMoveScript.PlayerGold >= 100 && HealthSlider.points >= 2)
        {
            this.audioSource.PlayOneShot(this.BuyItemSound);
            PlayerMoveScript.PlayerGold -= 100;
            this.levelOneShield.SetActive(false);
            this.levelTwoShield.SetActive(true);
            PlayerMoveScript.PlayerMaxHp += 25;
            PlayerMoveScript.PlayerHp += 25;
            shieldTwo = true;
            shieldThree = false;
            this.shieldTwoButton.SetActive(false);
            ShieldLevel++;
        }
    }

    public void UpdateShieldThree()
    {
        if (PlayerMoveScript.PlayerGold >= 200 && HealthSlider.points >= 4)
        {
            this.audioSource.PlayOneShot(this.BuyItemSound);
            PlayerMoveScript.PlayerGold -= 200;
            this.levelTwoShield.SetActive(false);
            this.levelThreeShield.SetActive(true);
            PlayerMoveScript.PlayerMaxHp += 50;
            PlayerMoveScript.PlayerHp += 50;
            shieldTwo = false;
            shieldThree = true;
            this.shieldThreeButton.SetActive(false);
            ShieldLevel++;
        }
    }

    public void Exit()
    {
        this.gameObject.SetActive(false);
    }
}