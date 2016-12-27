using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectScript : MonoBehaviour
{
    private int worldIndex;
    private int levelIndex;
    private int stars = 0;

    void Start()
    {
        for (int i = 1; i <= LockLevel.worlds; i++)
        {
            if (Application.loadedLevelName == "World" + i)
            {
                //Application.loadedLevelName == "World" + i
                worldIndex = i;  
                CheckLockedLevels();  
            }
        }
    }

    public void Selectlevel(string worldLevel)
    {
        Application.LoadLevel("Level" + worldLevel);
    }

    void CheckLockedLevels()
    {
        for (int j = 1; j < LockLevel.levels; j++)
        {
            stars = PlayerPrefs.GetInt("level" + worldIndex.ToString() + ":" + j.ToString() + "stars");
            levelIndex = (j + 1);
            GameObject.Find(j + "star" + stars).GetComponent<Image>().enabled = true;
            if ((PlayerPrefs.GetInt("level" + worldIndex.ToString() + ":" + levelIndex.ToString())) == 1)
            {
                GameObject.Find("LockedLevel" + levelIndex).SetActive(false);
            }
        }
    }
}