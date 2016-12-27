using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    private Text level;
    private Text turns;
    private Text dmg;
    private Text health;
    private Text mana;
    private Text exp;
    private Text gold;
    private Text swordLevel;
    private Text shieldLevel;

    private void Awake()
    {
        this.level = GameObject.Find("PlayerLevelStats").GetComponent<Text>();
        this.turns = GameObject.Find("TurnsStats").GetComponent<Text>();
        this.dmg = GameObject.Find("DmgStats").GetComponent<Text>();
        this.health = GameObject.Find("HealthStats").GetComponent<Text>();
        this.mana = GameObject.Find("ManaStats").GetComponent<Text>();
        this.exp = GameObject.Find("ExpStats").GetComponent<Text>();
        this.gold = GameObject.Find("GoldStats").GetComponent<Text>();
        this.swordLevel = GameObject.Find("SwordLevelStats").GetComponent<Text>();
        this.shieldLevel = GameObject.Find("ShieldLevelStats").GetComponent<Text>();
    }

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        this.level.text = "Level: " + PlayerMoveScript.PlayerLevel;
        this.turns.text = "Turns made: " + PlayerMoveScript.Turns.ToString();
        this.dmg.text = "DMG: " + PlayerMoveScript.PlayerMinDmg + " - " + PlayerMoveScript.PlayerMaxDmg;
        this.health.text = "Health: " + PlayerMoveScript.PlayerHp + "/" + PlayerMoveScript.PlayerMaxHp;
        this.mana.text = "Mana: " + PlayerMoveScript.PlayerMana + "/" + PlayerMoveScript.PlayerMaxMana;
        this.exp.text = "Exp: " + PlayerMoveScript.PlayerExp + "/" + PlayerMoveScript.PlayerMaxExp;
        this.gold.text = "Gold: " + PlayerMoveScript.PlayerGold.ToString();
        this.swordLevel.text = "Sword update: " + Shop.SwordLevel;
        this.shieldLevel.text = "Shield update: " + Shop.ShieldLevel;
    }
}
