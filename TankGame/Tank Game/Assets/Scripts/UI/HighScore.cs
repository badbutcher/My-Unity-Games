using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text BestScore;

    void Start()
    {
        CoinRotator.change = (PlayerPrefs.GetInt("Name") != 0);
    }

    void Update()
    {
        BestScore.text = "Endless High Score: " + PlayerPrefs.GetFloat("highScore");
    }
}
