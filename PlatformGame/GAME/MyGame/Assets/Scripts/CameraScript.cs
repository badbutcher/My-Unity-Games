using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset;

    private void Start()
    {
        this.player = GameObject.FindWithTag("Player");
        this.offset = transform.position - this.player.transform.position;       
    }

    private void Update()
    {
        transform.position = this.player.transform.position + this.offset;
    }
}