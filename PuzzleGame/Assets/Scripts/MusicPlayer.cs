using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if (objs.Length > 1)
        {
            MonoBehaviour.Destroy(this.gameObject);
        }

        MonoBehaviour.DontDestroyOnLoad(this.gameObject);
    }
}