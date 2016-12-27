using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public static float Coins;
    public static float Score;
    public Text score;
    public Text coins;

    void Update()
    {
        coins.text = "Coins: " + Coins;
        score.text = "Score: " + Score;
        if (Input.GetKeyDown(KeyCode.F12))
        {
            Coins += 100;
        }  
    }

    void Start()
    {
        coins.text = "Coins: " + Coins;
        score.text = "Score: " + Score;
    } 
}