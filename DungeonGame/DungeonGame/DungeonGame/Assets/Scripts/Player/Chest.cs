using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    private int gold;
    private float randomDrop;
    private Text youFoundHealth;
    private Text youFoundMana;
    private Text youFoundGold;
    private Text youFoundSuperPot;
    private GameObject healthPotImage;
    private GameObject manaPotImage;
    private GameObject superPotImage;
    private GameObject goldImage;
    private GameObject background;

    private AudioSource audioSource;

    public AudioClip OpenChestSound;
    private bool chestFound;

    private void Awake()
    {
        this.audioSource = this.GetComponent<AudioSource>();
        this.healthPotImage = GameObject.Find("HealthChestImage");
        this.manaPotImage = GameObject.Find("ManaChestImage");
        this.goldImage = GameObject.Find("GoldChestImage");
        this.background = GameObject.Find("ItemFoundBackground");
        this.superPotImage = GameObject.Find("SuperPotChestImage");
        this.youFoundHealth = GameObject.Find("ChestHealthText").GetComponent<Text>();
        this.youFoundMana = GameObject.Find("ChestManaText").GetComponent<Text>();
        this.youFoundGold = GameObject.Find("ChestGoldText").GetComponent<Text>();
        this.youFoundSuperPot = GameObject.Find("ChestSuperPotText").GetComponent<Text>();
    }
    
    private void Start()
    {
        chestFound = false;
        if (PlayerMoveScript.CurrentStage >= 5)
        {
            this.gold = Random.Range(40, 81);
        }
        else
        {
            this.gold = Random.Range(20, 56);
        }

        this.randomDrop = Random.value;
        this.healthPotImage.SetActive(false);
        this.manaPotImage.SetActive(false);
        this.superPotImage.SetActive(false);
        this.goldImage.SetActive(false);
        this.background.SetActive(false);
        this.youFoundGold.text = string.Empty;
        this.youFoundHealth.text = string.Empty;
        this.youFoundMana.text = string.Empty;
    }

    private void Update()
    {
        RaycastHit hit;
        Ray forward = new Ray(transform.position, transform.up);
        Debug.DrawRay(transform.position, transform.up * 10);
        if (Physics.Raycast(forward, out hit, 10))
        {
            if (hit.collider.gameObject.tag == "Player" && !chestFound)
            {
                chestFound = true;
                this.audioSource.PlayOneShot(this.OpenChestSound);
                if (this.randomDrop > 0.9) ////10%
                {
                    PlayerMoveScript.PlayerSuperPosts += 1;
                    this.StartCoroutine(this.WaitSuperPot());
                }
                else if (this.randomDrop > 0.8) ////20%
                {
                    PlayerMoveScript.PlayerManaPosts += 1;
                    this.StartCoroutine(this.WaitMana());
                }
                else if (this.randomDrop > 0.7) ////30%
                {
                    PlayerMoveScript.PlayerHealthPosts += 1;
                    this.StartCoroutine(this.WaitHealth());
                }
                else
                {
                    PlayerMoveScript.PlayerGold += this.gold;
                    this.StartCoroutine(this.WaitGold());
                }
            }
        }
    }

    public IEnumerator WaitHealth()
    {
        this.background.SetActive(true);
        this.healthPotImage.SetActive(true);
        this.youFoundHealth.text = "You found 1 health potion";
        yield return new WaitForSeconds(2.5f);
        this.youFoundHealth.text = string.Empty;
        this.healthPotImage.SetActive(false);
        this.background.SetActive(false);
        MonoBehaviour.Destroy(this.gameObject);
        chestFound = false;
    }

    public IEnumerator WaitMana()
    {
        this.background.SetActive(true);
        this.manaPotImage.SetActive(true);
        this.youFoundMana.text = "You found 1 mana potion";
        yield return new WaitForSeconds(2.5f);
        this.youFoundMana.text = string.Empty;
        this.manaPotImage.SetActive(false);
        this.background.SetActive(false);
        MonoBehaviour.Destroy(this.gameObject);
        chestFound = false;
    }

    public IEnumerator WaitSuperPot()
    {
        this.background.SetActive(true);
        this.superPotImage.SetActive(true);
        this.youFoundSuperPot.text = "You found 1 SUPER potion";
        yield return new WaitForSeconds(2.5f);
        this.youFoundSuperPot.text = string.Empty;
        this.superPotImage.SetActive(false);
        this.background.SetActive(false);
        MonoBehaviour.Destroy(this.gameObject);
        chestFound = false;
    }

    public IEnumerator WaitGold()
    {
        this.background.SetActive(true);
        this.youFoundGold.text = "You found: " + this.gold + " Gold";
        this.goldImage.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        this.youFoundGold.text = string.Empty;
        this.goldImage.SetActive(false);
        this.background.SetActive(false);
        MonoBehaviour.Destroy(this.gameObject);
        chestFound = false;
    }
}