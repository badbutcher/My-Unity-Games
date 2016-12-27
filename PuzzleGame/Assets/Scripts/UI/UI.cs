using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public SpawnPlatforms SpawnPlatforms;
    public Border Border;
    public GameObject YouWonScreen;
    public GameObject YouLoseScreen;
    public Image Clock;
    protected string currentLevel;

    public GameObject PauseMenu;

    public Toggle MusicToggle;
    public GameObject MusicToggleBackground;
    public Sprite MusicOnImage;
    public Sprite MusicOffImage;

    private GameObject music;

    private AudioSource audioSource;

    public GameObject BackgroundLevel;
    public Sprite[] RandomBackgroundsSprites;

    void Awake()
    {
        this.music = GameObject.FindGameObjectWithTag("Music");
        this.audioSource = this.music.GetComponent<AudioSource>();
    }

    void Start()
    {
        this.currentLevel = SceneManager.GetActiveScene().name;
        this.MusicToggleBackground.GetComponent<Image>().sprite = this.MusicOnImage;
        this.BackgroundLevel.GetComponent<SpriteRenderer>().sprite = this.RandomBackgroundsSprites[Random.Range(0, this.RandomBackgroundsSprites.Length)];
    }

    void Update()
    {
        this.Clock.fillAmount = this.SpawnPlatforms.Timer / 6.0f;

        if (this.SpawnPlatforms.YouWon)
        {
            this.YouWonScreen.SetActive(true);
        }

        if (this.Border.YouLose)
        {
            Cursor.visible = true;
            this.YouLoseScreen.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.PauseMenu.SetActive(true);
            Cursor.visible = true;
        }
    }

    public void NextLevel()
    {
        string[] nextLevel = this.currentLevel.Split('-');
        int levelNumber = int.Parse(nextLevel[1]) + 1;
        SceneManager.LoadScene("Level-" + levelNumber);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void HideCursor()
    {
        Cursor.visible = false;
    }

    public void MusicToggleUI()
    {
        if (this.MusicToggle.isOn)
        {
            this.audioSource.Play();
            this.MusicToggleBackground.GetComponent<Image>().sprite = this.MusicOnImage;
        }
        else
        {
            this.audioSource.Stop();
            this.MusicToggleBackground.GetComponent<Image>().sprite = this.MusicOffImage;
        }
    }
}