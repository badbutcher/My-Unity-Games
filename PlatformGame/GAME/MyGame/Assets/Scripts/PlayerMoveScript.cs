using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMoveScript : MonoBehaviour
{
    public float SpringPower;
    public float JumpPower;
    public float MoveSpeed;
    public AudioClip JumpSound;
    public AudioClip PlayerDie;
    public AudioClip StarPickUp;
    public AudioClip LevelFinish;
    public AudioClip Spring;

    private int CollectedStars;
    private GameObject star1;
    private GameObject star2;
    private GameObject star3;
    private GameObject wellDone;
    private bool isDead;
    private bool moveLeftOn = false;
    private bool moveRightOn = false;
    private bool jumpIsOn = false;
    private Rigidbody rb;
    private Camera cam;
    private AudioSource source;
    private bool levelWon;

    protected string currentLevel;
    protected int worldIndex;
    protected int levelIndex;

    private void Awake()
    {
        this.source = this.GetComponent<AudioSource>();
    }

    private void Start()
    {
        levelWon = false;
        star1 = GameObject.Find("star1");
        star2 = GameObject.Find("star2");
        star3 = GameObject.Find("star3");
        wellDone = GameObject.Find("WellDone");

        star1.GetComponent<Image>().enabled = false;
        star2.GetComponent<Image>().enabled = false;
        star3.GetComponent<Image>().enabled = false;
        wellDone.GetComponent<Image>().enabled = false;

        currentLevel = Application.loadedLevelName;
        CollectedStars = 0;
        this.isDead = false;
        this.rb = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.P))
        {
            PlayerPrefs.DeleteAll();
        }
        if (!this.isDead && !levelWon)
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, Vector3.down);
            if (Physics.Raycast(ray, out hit, 1))
            {
                if (this.jumpIsOn)
                {
                    this.source.PlayOneShot(this.JumpSound);
                    this.rb.AddForce(new Vector3(0, JumpPower, 0), ForceMode.Impulse);
                    this.jumpIsOn = false;
                }
            }

            if (this.moveLeftOn)
            {
                this.transform.eulerAngles = new Vector3(270, 90, 0);
                this.transform.Translate(0, this.MoveSpeed * Time.deltaTime, 0);
            }

            if (this.moveRightOn)
            {
                this.transform.eulerAngles = new Vector3(270, 270, 0);
                this.transform.Translate(0, this.MoveSpeed * Time.deltaTime, 0);
            }

            //Todo: remove!!!!!!
            if (Input.GetKey(KeyCode.A))
            {
                this.transform.eulerAngles = new Vector3(270, 90, 0);
                this.transform.Translate(0, this.MoveSpeed * Time.deltaTime, 0);
            }

            if (Input.GetKey(KeyCode.D))
            {
                this.transform.eulerAngles = new Vector3(270, 270, 0);
                this.transform.Translate(0, this.MoveSpeed * Time.deltaTime, 0);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.source.PlayOneShot(this.JumpSound);
                this.rb.AddForce(new Vector3(0, 14f, 0), ForceMode.Impulse);
                this.jumpIsOn = false;
            }
        }

        if (this.isDead)
        {
            this.transform.Rotate(0f, 0f, 5f);
        }

        this.rb.AddForce(new Vector3(0, -4, 0), ForceMode.Force);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            this.isDead = true;
            this.source.PlayOneShot(this.PlayerDie, 1);
            MonoBehaviour.Destroy(this.gameObject, 1.39f);
        }

        if (col.gameObject.tag == "Flag")
        {
            levelWon = true;
            this.source.PlayOneShot(this.LevelFinish, 1);
            wellDone.GetComponent<Image>().enabled = true;

            if (CollectedStars == 3)
            {
                star3.GetComponent<Image>().enabled = true;
                UnlockLevels(3);
            }
            else if (CollectedStars == 2)
            {
                star2.GetComponent<Image>().enabled = true;
                UnlockLevels(2);
            }
            else if (CollectedStars == 1)
            {
                star1.GetComponent<Image>().enabled = true;
                UnlockLevels(1);
            }

            UnlockLevels(CollectedStars);
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {

        yield return new WaitForSeconds(5);
        Application.LoadLevel("World1");
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Star")
        {
            CollectedStars++;
            this.source.PlayOneShot(this.StarPickUp, 1);
            MonoBehaviour.Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Spring")
        {
            this.source.PlayOneShot(this.Spring, SpringPower);
            this.rb.AddForce(new Vector3(0, 20f, 0), ForceMode.Impulse);
        }
    }

    protected void UnlockLevels(int stars)
    {
        for (int i = 0; i < LockLevel.worlds; i++)
        {
            for (int j = 1; j < LockLevel.levels; j++)
            {
                if (currentLevel == "Level" + (i + 1).ToString() + "." + j.ToString())
                {
                    worldIndex = (i + 1);
                    levelIndex = (j + 1);
                    PlayerPrefs.SetInt("level" + worldIndex.ToString() + ":" + levelIndex.ToString(), 1);

                    if (PlayerPrefs.GetInt("level" + worldIndex.ToString() + ":" + j.ToString() + "stars") < stars)

                    {
                        PlayerPrefs.SetInt("level" + worldIndex.ToString() + ":" + j.ToString() + "stars", stars);
                    }
                }
            }
        }
    }

    public void MoveLeftIsDown()
    {
        this.moveLeftOn = true;
    }

    public void MoveLeftIsUp()
    {
        this.moveLeftOn = false;
    }

    public void MoveRightIsDown()
    {
        this.moveRightOn = true;
    }

    public void MoveRightIsUp()
    {
        this.moveRightOn = false;
    }

    public void JumpIsDown()
    {
        this.jumpIsOn = true;
    }

    public void JumpIsUp()
    {
        this.jumpIsOn = false;
    }
}