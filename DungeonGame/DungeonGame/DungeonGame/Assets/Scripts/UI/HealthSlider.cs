using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    private Slider slider;
    public static float points = 0;

    private void Awake()
    {
        this.slider = GameObject.Find("HealthSlider").GetComponent<Slider>();
        this.slider.value = points;
    }

    public void AddPoints()
    {
        if (this.slider.value != 5 && PlayerMoveScript.SkillPoints >= 1)
        {
            PlayerMoveScript.PlayerMaxHp += 20;
            PlayerMoveScript.PlayerHp += 35;
            if (PlayerMoveScript.PlayerHp >= PlayerMoveScript.PlayerMaxHp)
            {
                PlayerMoveScript.PlayerHp = PlayerMoveScript.PlayerMaxHp;
            }
            PlayerMoveScript.SkillPoints--;
            this.slider.value++;
            points = this.slider.value;
        }
    }
}