using UnityEngine;
using UnityEngine.UI;

public class DamageSlider : MonoBehaviour
{
    public Slider slide;

    public void AddPoints()
    {
        if (slide.value != 21 && MoneyManager.Coins >= 30)
        {
            slide.value++;
            MoneyManager.Coins -= 30;
            TurretHealth.DamageFromPlayer += 10;
            EnemyTankHealth.EnemyTankDamageFromPlayer += 10;
        }
    }
}