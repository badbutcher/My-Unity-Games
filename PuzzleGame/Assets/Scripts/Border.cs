using UnityEngine;

public class Border : MonoBehaviour
{
    public bool YouLose;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform")
        {
            this.YouLose = true;
        }
    }
}