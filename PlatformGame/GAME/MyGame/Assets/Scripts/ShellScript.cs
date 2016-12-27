using UnityEngine;

public class ShellScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            MonoBehaviour.Destroy(this.gameObject);
        }

        if (col.gameObject.tag != "Player")
        {
            MonoBehaviour.Destroy(this.gameObject);
        }
    }
}