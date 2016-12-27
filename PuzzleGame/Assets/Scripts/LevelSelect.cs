using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    private int levelIndex;

    void Start()
    {
        this.CheckLockedLevels();
    }

    public void Selectlevel(string worldLevel)
    {
        SceneManager.LoadScene("Level-" + worldLevel);
    }

    void CheckLockedLevels()
    {
        for (int j = 1; j < LockLevel.Levels; j++)
        {
            this.levelIndex = (j + 1);

            if ((PlayerPrefs.GetInt("level" + this.levelIndex.ToString())) == 1)
            {
                GameObject.Find("LockedLevel" + (j + 1)).SetActive(false);
            }
        }
    }
}