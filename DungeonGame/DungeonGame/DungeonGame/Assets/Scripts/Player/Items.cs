using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    private Text healthPots;
    private Text manaPots;
    private Text superPots;

    private AudioSource audioSource;
    public AudioClip UseItemSound;

    private void Awake()
    {
        this.audioSource = this.GetComponent<AudioSource>();
        this.healthPots = GameObject.Find("HealthPotsLeft").GetComponent<Text>();
        this.manaPots = GameObject.Find("ManaPotsLeft").GetComponent<Text>();
        this.superPots = GameObject.Find("SuperPotsLeft").GetComponent<Text>();
    }

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        this.healthPots.text = string.Empty + PlayerMoveScript.PlayerHealthPosts;
        this.manaPots.text = string.Empty + PlayerMoveScript.PlayerManaPosts;
        this.superPots.text = string.Empty + PlayerMoveScript.PlayerSuperPosts;
    }

    public void UseHealthPot()
    {
        if (PlayerMoveScript.PlayerHealthPosts >= 1 && PlayerMoveScript.PlayerHp < PlayerMoveScript.PlayerMaxHp)
        {
            this.audioSource.PlayOneShot(this.UseItemSound);
            PlayerMoveScript.PlayerHp += 35;
            if (PlayerMoveScript.PlayerHp >= PlayerMoveScript.PlayerMaxHp)
            {
                PlayerMoveScript.PlayerHp = PlayerMoveScript.PlayerMaxHp;
            }

            PlayerMoveScript.PlayerHealthPosts--;            
        }
    }

    public void UseManaPot()
    {
        if (PlayerMoveScript.PlayerManaPosts >= 1 && PlayerMoveScript.PlayerMana < PlayerMoveScript.PlayerMaxMana)
        {
            this.audioSource.PlayOneShot(this.UseItemSound);
            PlayerMoveScript.PlayerMana += 35;
            if (PlayerMoveScript.PlayerMana >= PlayerMoveScript.PlayerMaxMana)
            {
                PlayerMoveScript.PlayerMana = PlayerMoveScript.PlayerMaxMana;
            }

            PlayerMoveScript.PlayerManaPosts--;
        }
    }

    public void UseSuperPot()
    {
        if (PlayerMoveScript.PlayerSuperPosts >= 1)
        {
            this.audioSource.PlayOneShot(this.UseItemSound);
            PlayerMoveScript.PlayerHp += 75;
            PlayerMoveScript.PlayerMana += 75;
            if (PlayerMoveScript.PlayerMana >= PlayerMoveScript.PlayerMaxMana)
            {
                PlayerMoveScript.PlayerMana = PlayerMoveScript.PlayerMaxMana;
            }

            if (PlayerMoveScript.PlayerHp >= PlayerMoveScript.PlayerMaxHp)
            {
                PlayerMoveScript.PlayerHp = PlayerMoveScript.PlayerMaxHp;
            }

            PlayerMoveScript.PlayerSuperPosts--;
        }
    }
}