using UnityEngine;
using System.Collections;

public class LockLevel : MonoBehaviour
{
    public static int worlds = 1;
    public static int levels = 21;

    private int worldIndex;
    private int levelIndex;

    void Start()
    {
        PlayerPrefs.DeleteAll();
        LockLevels();
    }

    void LockLevels()
    {
        for (int i = 0; i < worlds; i++)
        {
            for (int j = 1; j < levels; j++)
            {
                worldIndex = (i + 1);
                levelIndex = (j + 1);
                if (!PlayerPrefs.HasKey("level" + worldIndex.ToString() + ":" + levelIndex.ToString()))
                {
                    PlayerPrefs.SetInt("level" + worldIndex.ToString() + ":" + levelIndex.ToString(), 0);
                }
            }
        }
    }
}