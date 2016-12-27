using UnityEngine;

public class ShowHideSpells : MonoBehaviour
{
    private GameObject menu;

    private void Awake()
    {
        this.menu = GameObject.Find("SpellsMenu");
    }

    public void ShowSpellsMenu()
    {
        this.menu.SetActive(true);
    }

    public void HideSpellsMenu()
    {
        this.menu.SetActive(false);
    }
}