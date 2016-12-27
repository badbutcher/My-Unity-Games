using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerMoveScript : MonoBehaviour
{
    private bool playerDead;

    public static int PlayerMinDmg = 1;
    public static int PlayerMaxDmg = 3;
    private int playerDmg = 0;

    public static float PlayerHp = 100;
    public static float PlayerMaxHp = 100;
    private Text healthText;

    public static float PlayerMana = 100;
    public static float PlayerMaxMana = 100;
    private Text manaText;

    public static float PlayerExp = 0;
    public static float PlayerMaxExp = 10;
    public static float PlayerLevel = 1;

    public static float SkillPoints = 0;
    public static float Turns = 0;

    public static int PlayerGold = 0;
    public static int PlayerHealthPosts = 0;
    public static int PlayerManaPosts = 1;
    public static int PlayerSuperPosts = 0;

    public static bool EnemyFound;
    private bool enemyDead;

    private Canvas skillMenu;
    private Slider healthSlider;
    private Slider manaSlider;
    private bool skeletonFound;
    private bool zombieFound;
    private bool eyeFound;
    private bool uglyHydraFound;

    private bool moveRight;
    private bool moveLeft;
    private bool moveBack;
    private bool moveForward;
    private bool canMoveBack;
    private bool canMoveForward;
    public static int CurrentStage = 0;

    private SkeletonStats skeletonStats;
    private ZombieStats zombieStats;
    private EyeStats eyeStats;
    private UglyHydraStats uglyHydraStats;

    private Text showPoints;
    private GameObject enemyHpBackground;

    private GameObject shopButton;

    private GameObject powerAttackOn;
    private GameObject lifeStealkOn;

    private GameObject slashOne;
    private GameObject slashTwo;
    private GameObject slashThree;

    private AudioSource audioSource;

    public AudioClip WalkOneSound;
    public AudioClip WalkTwoSound;
    public AudioClip WalkThreeSound;
    public AudioClip WalkFourSound;
    public AudioClip SlashOneSound;
    public AudioClip SlashTwoSound;
    public AudioClip SlashThreeSound;
    public AudioClip SkeletonFoundSound;
    public AudioClip ZombieFoundSound;
    public AudioClip EyeFoundSound;
    public AudioClip LevelUpSound;
    public AudioClip DieSound;
    public AudioClip UglyHydraFoundSound;
    public AudioClip DoorOpenSound;

    private GameObject door;
    private GameObject deadScreen;

    private GameObject LoadingScreen;

    private void Awake()
    {
        this.LoadingScreen = GameObject.Find("LoadingScreen");
        this.deadScreen = GameObject.Find("/PlayerComponents/Controlls/DeadScreen");
        this.slashOne = GameObject.Find("/PlayerComponents/Controlls/SlashOneImage");
        this.slashTwo = GameObject.Find("/PlayerComponents/Controlls/SlashTwoImage");
        this.slashThree = GameObject.Find("/PlayerComponents/Controlls/SlashThreeImage");
        this.powerAttackOn = GameObject.Find("/PlayerComponents/Player/PowerAttackEmitor");
        this.lifeStealkOn = GameObject.Find("/PlayerComponents/Player/LifeStealEmitor");
        this.audioSource = this.GetComponent<AudioSource>();
        this.enemyHpBackground = GameObject.Find("/PlayerComponents/Controlls/EnemyHpBackground");
        this.healthText = GameObject.Find("/PlayerComponents/Controlls/PlayerHealthText").GetComponent<Text>();
        this.manaText = GameObject.Find("/PlayerComponents/Controlls/PlayerManaText").GetComponent<Text>();
        this.showPoints = GameObject.Find("/PlayerComponents/SkillMenu/SkillPoitsLeft").GetComponent<Text>();
        this.shopButton = GameObject.Find("/PlayerComponents/Controlls/ShopButton");
        this.enemyHpBackground.SetActive(false);
        this.skillMenu = GameObject.Find("/PlayerComponents/SkillMenu").GetComponent<Canvas>();
        this.healthSlider = GameObject.Find("/PlayerComponents/Controlls/Health").GetComponent<Slider>();
        this.manaSlider = GameObject.Find("/PlayerComponents/Controlls/Mana").GetComponent<Slider>();
    }

    private void Start()
    {
        this.LoadingScreen.SetActive(false);
        this.deadScreen.SetActive(false);
        CurrentStage = SceneManager.GetActiveScene().buildIndex;
        this.skillMenu.GetComponent<Canvas>().enabled = false;
        this.slashOne.SetActive(false);
        this.slashTwo.SetActive(false);
        this.slashThree.SetActive(false);
        if (CurrentStage >= 6)
        {
            PlayerPrefs.SetFloat("Unlocked", 1);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            PlayerPrefs.DeleteAll();
        }

        if (PlayerHp <= 0)
        {
            PlayerHp = 0;
            if (!this.playerDead)
            {
                this.audioSource.PlayOneShot(this.DieSound);
                this.playerDead = true;
            }

            this.deadScreen.SetActive(true);
        }

        if (EnemyFound)
        {
            this.enemyHpBackground.SetActive(true);
        }
        else
        {
            this.enemyHpBackground.SetActive(false);
        }

        if (!Spells.PowerAttack)
        {
            this.powerAttackOn.SetActive(false);
        }
        else
        {
            this.powerAttackOn.SetActive(true);
        }

        if (!Spells.LifeStealReady)
        {
            this.lifeStealkOn.SetActive(false);
        }
        else
        {
            this.lifeStealkOn.SetActive(true);
        }

        this.healthText.text = PlayerHp.ToString();
        this.manaText.text = PlayerMana.ToString();
        this.healthSlider.maxValue = PlayerMaxHp;
        this.manaSlider.maxValue = PlayerMaxMana;
        this.healthSlider.value = PlayerHp;
        this.manaSlider.value = PlayerMana;
        this.showPoints.text = SkillPoints.ToString();

        if (PlayerExp >= PlayerMaxExp)
        {
            this.audioSource.PlayOneShot(this.LevelUpSound);
            float leftOverXp = PlayerExp - PlayerMaxExp;
            PlayerLevel += 1;
            PlayerMaxExp += 10;
            SkillPoints += 1;
            PlayerExp = leftOverXp;
            this.skillMenu.GetComponent<Canvas>().enabled = true;
        }

        this.playerDmg = Random.Range(PlayerMinDmg, PlayerMaxDmg + 1);

        RaycastHit hit;
        Ray forward = new Ray(transform.position, transform.forward);
        Ray back = new Ray(transform.position, -transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 10);
        Debug.DrawRay(transform.position, -transform.forward * 10);
        if (Physics.Raycast(forward, out hit, 10))
        {
            if (hit.collider.gameObject.tag == "Wall")
            {
                this.canMoveForward = false;
                this.moveForward = false;
            }

            if (hit.collider.gameObject.name == "Key")
            {
                this.audioSource.PlayOneShot(this.DoorOpenSound);
                MonoBehaviour.Destroy(hit.collider.gameObject);
                MonoBehaviour.Destroy(this.door = GameObject.Find("Door"));
            }

            if (hit.collider.gameObject.name == "Skeleton")
            {
                if (!EnemyFound)
                {
                    this.audioSource.PlayOneShot(this.SkeletonFoundSound);
                    this.transform.LookAt(hit.point);
                    hit.transform.LookAt(this.transform.position);
                    hit.transform.Rotate(260, 0, 0);
                    hit.transform.Translate(Vector3.down * 5);
                    this.skeletonStats = hit.collider.gameObject.AddComponent<SkeletonStats>();
                    EnemyFound = true;
                    this.skeletonFound = true;
                }
            }

            if (hit.collider.gameObject.name == "Eye")
            {
                if (!EnemyFound)
                {
                    this.audioSource.PlayOneShot(this.EyeFoundSound);
                    this.transform.LookAt(hit.point);
                    hit.transform.LookAt(this.transform.position);
                    hit.transform.Rotate(260, 0, 0);
                    hit.transform.Translate(Vector3.down * 5);
                    this.eyeStats = hit.collider.gameObject.AddComponent<EyeStats>();
                    EnemyFound = true;
                    this.eyeFound = true;
                }
            }

            if (hit.collider.gameObject.name == "Zombie")
            {
                if (!EnemyFound)
                {
                    this.audioSource.PlayOneShot(this.ZombieFoundSound);
                    this.transform.LookAt(hit.point);
                    hit.transform.LookAt(this.transform.position);
                    hit.transform.Rotate(260, 0, 0);
                    hit.transform.Translate(Vector3.down * 5);
                    this.zombieStats = hit.collider.gameObject.AddComponent<ZombieStats>();
                    EnemyFound = true;
                    this.zombieFound = true;
                }
            }

            if (hit.collider.gameObject.name == "UglyHydra")
            {
                if (!EnemyFound)
                {
                    this.audioSource.PlayOneShot(this.UglyHydraFoundSound);
                    this.transform.LookAt(hit.point);
                    hit.transform.LookAt(this.transform.position);
                    hit.transform.Rotate(260, 0, 0);
                    hit.transform.Translate(Vector3.down * 2);
                    this.uglyHydraStats = hit.collider.gameObject.AddComponent<UglyHydraStats>();
                    EnemyFound = true;
                    this.uglyHydraFound = true;
                }
            }
        }
        else
        {
            this.canMoveForward = true;
        }

        if (Physics.Raycast(back, out hit, 10))
        {
            if (hit.collider.gameObject.tag == "Wall")
            {
                this.canMoveBack = false;
                this.moveBack = false;
            }
        }
        else
        {
            this.canMoveBack = true;
        }

        if (CurrentStage % 3 == 0)
        {
            this.shopButton.SetActive(true);
        }
        else
        {
            this.shopButton.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Exit")
        {
            Destroy(other.gameObject);
            StartCoroutine(Loading());
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (this.canMoveForward)
        {
            this.moveForward = true;
        }

        if (this.canMoveBack)
        {
            this.moveBack = true;
        }
    }

    IEnumerator Loading()
    {
        this.LoadingScreen.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(CurrentStage + 1);
        this.transform.position = new Vector3(0, 1, 0);
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        CurrentStage++;
    }

    public void GoUp()
    {
        this.RandomSteps();
        if (!EnemyFound)
        {
            if (this.moveForward)
            {
                Turns++;
                this.transform.Translate(0, 0, 10);
            }
        }
    }

    public void GoDown()
    {
        this.RandomSteps();
        if (!EnemyFound)
        {
            if (this.moveBack)
            {
                Turns++;
                this.transform.Translate(0, 0, -10);
            }
        }
    }

    public void GoLeft()
    {
        this.RandomSteps();
        if (!EnemyFound)
        {
            Turns++;
            this.transform.Rotate(0, -90, 0);
        }
    }

    public void GoRight()
    {
        this.RandomSteps();
        if (!EnemyFound)
        {
            Turns++;
            this.transform.Rotate(0, 90, 0);
        }
    }

    public void GoAttack()
    {
        if (EnemyFound)
        {
            this.StartCoroutine(this.SlashAttack());
            if (this.skeletonFound)
            {
                Turns++;
                this.skeletonStats.SkeletonHp -= this.playerDmg;

                if (Spells.PowerAttack)
                {
                    this.skeletonStats.SkeletonHp -= 15;
                    Spells.PowerAttack = false;
                }

                if (Spells.LifeStealReady)
                {
                    PlayerHp += 4;
                    this.skeletonStats.SkeletonHp -= 10;
                    Spells.LifeStealReady = false;
                }

                if (this.skeletonStats.SkeletonHp <= 0 && EnemyFound)
                {
                    PlayerExp += this.skeletonStats.GiveExp;
                    this.skeletonFound = false;
                }
                else if (this.skeletonStats.SkeletonHp > 0 && EnemyFound)
                {
                    PlayerHp -= this.skeletonStats.SkeletonDmg;
                }
            }

            if (this.zombieFound)
            {
                Turns++;
                this.zombieStats.ZombieHp -= this.playerDmg;

                if (Spells.PowerAttack)
                {
                    this.zombieStats.ZombieHp -= 15;
                    Spells.PowerAttack = false;
                }

                if (Spells.LifeStealReady)
                {
                    PlayerHp += 5;
                    this.zombieStats.ZombieHp -= 10;
                    Spells.LifeStealReady = false;
                }

                if (this.zombieStats.ZombieHp <= 0 && EnemyFound)
                {
                    PlayerExp += this.zombieStats.GiveExp;
                    this.zombieFound = false;
                }
                else if (this.zombieStats.ZombieHp > 0 && EnemyFound)
                {
                    PlayerHp -= this.zombieStats.ZombieDmg;
                }
            }

            if (this.eyeFound)
            {
                Turns++;
                this.eyeStats.EyeHp -= this.playerDmg;

                if (Spells.PowerAttack)
                {
                    this.eyeStats.EyeHp -= 15;
                    Spells.PowerAttack = false;
                }

                if (Spells.LifeStealReady)
                {
                    PlayerHp += 5;
                    this.eyeStats.EyeHp -= 10;
                    Spells.LifeStealReady = false;
                }

                if (this.eyeStats.EyeHp <= 0 && EnemyFound)
                {
                    PlayerExp += this.eyeStats.GiveExp;
                    this.eyeFound = false;
                }
                else if (this.eyeStats.EyeHp > 0 && EnemyFound)
                {
                    PlayerHp -= this.eyeStats.EyeDmg;
                }
            }

            if (this.uglyHydraFound)
            {
                Turns++;
                this.uglyHydraStats.UglyHydraHp -= this.playerDmg;

                if (Spells.PowerAttack)
                {
                    this.uglyHydraStats.UglyHydraHp -= 15;
                    Spells.PowerAttack = false;
                }

                if (Spells.LifeStealReady)
                {
                    PlayerHp += 5;
                    this.uglyHydraStats.UglyHydraHp -= 10;
                    Spells.LifeStealReady = false;
                }

                if (this.uglyHydraStats.UglyHydraHp <= 0 && EnemyFound)
                {
                    PlayerExp += this.uglyHydraStats.GiveExp;
                    this.uglyHydraFound = false;
                }
                else if (this.uglyHydraStats.UglyHydraHp > 0 && EnemyFound)
                {
                    PlayerHp -= this.uglyHydraStats.UglyHydraDmg;
                }
            }
        }
    }

    public IEnumerator SlashAttack()
    {
        int rnd = Random.Range(0, 3);
        if (rnd == 0)
        {
            this.audioSource.PlayOneShot(this.SlashOneSound);
            this.slashOne.SetActive(true);
        }
        else if (rnd == 1)
        {
            this.audioSource.PlayOneShot(this.SlashTwoSound);
            this.slashTwo.SetActive(true);
        }
        else
        {
            this.audioSource.PlayOneShot(this.SlashThreeSound);
            this.slashThree.SetActive(true);
        }

        yield return new WaitForSeconds(0.2f);
        this.slashOne.SetActive(false);
        this.slashTwo.SetActive(false);
        this.slashThree.SetActive(false);
    }

    private void RandomSteps()
    {
        float random = Random.Range(0, 5);
        if (random == 0)
        {
            this.audioSource.PlayOneShot(this.WalkOneSound);
        }
        else if (random == 1)
        {
            this.audioSource.PlayOneShot(this.WalkTwoSound);
        }
        else if (random == 2)
        {
            this.audioSource.PlayOneShot(this.WalkThreeSound);
        }
        else
        {
            this.audioSource.PlayOneShot(this.WalkFourSound);
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}