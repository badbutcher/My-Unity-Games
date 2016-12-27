using UnityEngine;
using System.Collections;

public class KeyScript : MonoBehaviour
{
    public GameObject Door;

	void Update ()
    {
        this.transform.Rotate(0f, 0f, 2f);
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Destroy(Door);
        }
    }
}
