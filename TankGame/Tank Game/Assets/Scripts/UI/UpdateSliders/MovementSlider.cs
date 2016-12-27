using UnityEngine;
using UnityEngine.UI;

public class MovementSlider : MonoBehaviour
{
    public Slider slide;

    public void AddPoints()
    {
        if (slide.value != 11 && MoneyManager.Coins >= 20)
        {
            slide.value++;
            MoneyManager.Coins -= 20;
            MoveScript.moveSpeed += 2;
            MoveScript.rotateSpeed += 2;
        }
    }
}