using UnityEngine;
using UnityEngine.UI;

public class AttackSlider : MonoBehaviour
{
    private Slider slider;
    public static float points = 0;

    private void Awake()
    {
        this.slider = GameObject.Find("AttackSlider").GetComponent<Slider>();
        this.slider.value = points;
    }

    public void AddPoints()
    {
        if (this.slider.value != 5 && PlayerMoveScript.SkillPoints >= 1)
        {
            if (this.slider.value % 2 == 0)
            {
                PlayerMoveScript.PlayerMinDmg++;
            }

            this.slider.value++;
            points = this.slider.value;
            PlayerMoveScript.SkillPoints--;
            PlayerMoveScript.PlayerMaxDmg++;
        }
    }
}