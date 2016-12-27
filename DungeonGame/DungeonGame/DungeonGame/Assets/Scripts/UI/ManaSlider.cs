using UnityEngine;
using UnityEngine.UI;

public class ManaSlider : MonoBehaviour
{
    private Slider slider;
    public static float points = 0;

    private void Awake()
    {
        this.slider = GameObject.Find("ManaSlider").GetComponent<Slider>();
        this.slider.value = points;
    }

    public void AddPoints()
    {
        if (this.slider.value != 5 && PlayerMoveScript.SkillPoints >= 1)
        {
            PlayerMoveScript.PlayerMaxMana += 20;
            PlayerMoveScript.PlayerMana += 35;
            if (PlayerMoveScript.PlayerMana >= PlayerMoveScript.PlayerMaxMana)
            {
                PlayerMoveScript.PlayerMana = PlayerMoveScript.PlayerMaxMana;
            }
            PlayerMoveScript.SkillPoints--;
            this.slider.value++;
            points = this.slider.value;
        }
    }
}