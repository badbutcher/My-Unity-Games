using UnityEngine;

public class LockLevel : MonoBehaviour
{
    public static int Levels = 20;

    private int levelIndex;

    void Start()
    {
        PlayerPrefs.DeleteAll();
        this.LockLevels();
    }

    void LockLevels()
    {
        for (int j = 1; j < Levels; j++)
        {
            this.levelIndex = (j + 1);

            if (!PlayerPrefs.HasKey("level" + this.levelIndex.ToString()))
            {
                PlayerPrefs.SetInt("level" + this.levelIndex.ToString(), 0);
            }
        }
    }
}