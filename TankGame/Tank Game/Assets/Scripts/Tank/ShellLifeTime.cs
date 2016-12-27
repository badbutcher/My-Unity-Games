using UnityEngine;

public class ShellLifeTime : MonoBehaviour
{
    private float LifeTime = 10;

    void Update()
    {
        LifeTime -= Time.deltaTime;

        if (LifeTime <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
}