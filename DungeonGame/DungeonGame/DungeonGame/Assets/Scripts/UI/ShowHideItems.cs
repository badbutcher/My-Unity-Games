using UnityEngine;

public class ShowHideItems : MonoBehaviour
{
    private GameObject menu;

    private void Awake()
    {
        this.menu = GameObject.Find("ItemMenu");
    }

    public void ShowItemMenu()
    {
        this.menu.SetActive(true);
    }

    public void HideItemMenu()
    {
        this.menu.SetActive(false);
    }
}