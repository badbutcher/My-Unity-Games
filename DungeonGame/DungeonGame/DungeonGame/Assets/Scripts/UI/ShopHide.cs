using UnityEngine;

public class ShopHide : MonoBehaviour
{
    private GameObject shop;

    private void Awake()
    {
        this.shop = GameObject.Find("ShopMenu");
    }
    
    public void HideHide()
    {
        this.shop.SetActive(false);
    }

    public void Show()
    {
        this.gameObject.SetActive(false);
        this.shop.SetActive(true);
    }
}