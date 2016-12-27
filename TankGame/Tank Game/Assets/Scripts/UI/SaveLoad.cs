using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public void SaveData()
    {
        PlayerPrefs.SetFloat("Coins", MoneyManager.Coins);
        PlayerPrefs.SetFloat("Score", MoneyManager.Score);
    }

    public void LoadData()
    {
        MoneyManager.Coins = PlayerPrefs.GetFloat("Coins");
        MoneyManager.Score =  PlayerPrefs.GetFloat("Score");
    }
}