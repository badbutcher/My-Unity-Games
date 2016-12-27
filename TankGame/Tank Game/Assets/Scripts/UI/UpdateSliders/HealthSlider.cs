using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    public Slider slide;
    public static float BonusHp;

    public void AddPoints()
    {     
        if (slide.value != 21 && MoneyManager.Coins >= 20)
        {
            BonusHp += 50;
            slide.value++;
            MoneyManager.Coins -= 20;
            PlayerHealth.Health += 50;
        }   
    }
}