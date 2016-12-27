using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPlatforms : MonoBehaviour
{
    public Border Border;
    public Sprite Empty;
    public SpriteRenderer NextPlatformSprite;
    public GameObject[] Platforms;
    private int nextPlatform;
    public float Timer;
    public bool YouWon;

    protected string currentLevel;
    protected int worldIndex;
    protected int levelIndex;

    void Start()
    {
        Time.timeScale = 1;
        this.currentLevel = SceneManager.GetActiveScene().name;
        Cursor.visible = false;
        SpriteRenderer sr = this.Platforms[this.nextPlatform].GetComponent<SpriteRenderer>();
        this.NextPlatformSprite.sprite = sr.sprite;
    }

    void Update()
    {
        Vector2 mousePos = Input.mousePosition;

        if (Input.GetMouseButtonDown(0) && !this.Border.YouLose && !Cursor.visible)
        {
            Vector2 wordPos;
            wordPos = Camera.main.ScreenToWorldPoint(mousePos);

            if (this.nextPlatform != this.Platforms.Length)
            {
                MonoBehaviour.Instantiate(this.Platforms[this.nextPlatform], wordPos, this.Platforms[this.nextPlatform].transform.rotation);
                this.nextPlatform++;
                if (this.nextPlatform != this.Platforms.Length)
                {
                    SpriteRenderer sr = this.Platforms[this.nextPlatform].GetComponent<SpriteRenderer>();
                    this.NextPlatformSprite.sprite = sr.sprite;
                }
                else
                {
                    this.NextPlatformSprite.sprite = this.Empty;
                }
            }
        }

        if (this.nextPlatform == this.Platforms.Length)
        {
            this.CoolDown();
        }
    }

    private void CoolDown()
    {
        this.Timer += Time.deltaTime;

        if (this.Timer >= 6)
        {
            this.UnlockLevels();
        }
    }

    protected void UnlockLevels()
    {
        Time.timeScale = 0;

        for (int j = 1; j < LockLevel.Levels; j++)
        {
            if (this.currentLevel == "Level-" + j.ToString())
            {
                this.levelIndex = (j + 1);
                PlayerPrefs.SetInt("level" + this.levelIndex.ToString(), 1);
            }
        }

        Cursor.visible = true;
        this.YouWon = true;
    }
}