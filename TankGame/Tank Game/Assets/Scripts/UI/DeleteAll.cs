using UnityEngine;
using System.Collections;

public class DeleteAll : MonoBehaviour
{
    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
    }
}