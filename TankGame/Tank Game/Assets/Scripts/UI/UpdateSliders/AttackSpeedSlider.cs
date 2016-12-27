using UnityEngine;
using UnityEngine.UI;

public class AttackSpeedSlider : MonoBehaviour
{
    public Slider slide;

    public void AddPoints()
    {
        if (slide.value != 6 && MoneyManager.Coins >= 40)
        {
            slide.value++;
            MoneyManager.Coins -= 40;
            ShotShell.fireRate -= 0.1f;
        }
    }
}