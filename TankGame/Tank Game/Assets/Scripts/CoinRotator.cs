using UnityEngine;

public class CoinRotator : MonoBehaviour
{
    public static bool change = false;

    void Update()
    {
        transform.Rotate(1f, 0f, 0f);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            change = true;
            PlayerPrefs.SetInt("Name", (change ? 1 : 0));
            Destroy(this.gameObject);
        }
    }
}