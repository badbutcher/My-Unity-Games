using UnityEngine;
using System.Collections;

public class EnemyTankMove : MonoBehaviour
{
    private Vector3 newPos;
    public float EnemyTankMoveSpeed = 20;
    public static bool isInRange = false;
    public Transform Player;

    void OnTriggerStay(Collider other)
    {
        if (isInRange && other.gameObject.tag == "Player" && Vector3.Distance(this.transform.position, Player.position) > 50)
        {
            transform.Translate(0f, 0f, EnemyTankMoveSpeed * Time.deltaTime);
            transform.LookAt(other.transform.position);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInRange = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInRange = true;
        }
    }
}