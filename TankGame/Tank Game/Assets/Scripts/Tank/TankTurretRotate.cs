using UnityEngine;

public class TankTurretRotate : MonoBehaviour
{
    public float rotate = 0;

    void Update()
    {
        transform.Rotate(0f, 0f, Input.GetAxis("Mouse X") * rotate * Time.deltaTime);
    }
}