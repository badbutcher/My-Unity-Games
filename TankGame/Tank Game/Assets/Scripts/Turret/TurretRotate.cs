using UnityEngine;

public class TurretRotate : MonoBehaviour
{
    public float rotate = 0;

    private bool isInRange = false;

    void Update()
    {
        if (!isInRange)
        {
            transform.Rotate(0f, 0f, rotate * Time.deltaTime);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (isInRange && other.gameObject.tag == "Player")
        {
            transform.LookAt(other.transform.position);
            transform.eulerAngles = new Vector3(-450f, transform.localRotation.eulerAngles.y, 180f);
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