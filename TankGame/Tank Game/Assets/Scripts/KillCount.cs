using UnityEngine;
using System.Collections;

public class KillCount : MonoBehaviour
{
    public GameObject VictoryScreen;

    void Update()
    {
        if (CoinRotator.change == true)
        {
            VictoryScreen.SetActive(true);
        }
    }
}