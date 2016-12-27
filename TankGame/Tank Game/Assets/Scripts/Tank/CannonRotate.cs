using UnityEngine;

public class CannonRotate : MonoBehaviour
{
    public float rotateSpeed = 45f;

    private Vector3 v3Rotate = Vector3.zero;
    private float min = 80;
    private float max = 95;
    
    void Update()
    {
        v3Rotate.x += Input.GetAxis("Mouse Y") * rotateSpeed * -1 * Time.deltaTime;
        v3Rotate.x = Mathf.Clamp(v3Rotate.x, min, max);
        transform.localEulerAngles = v3Rotate;
    }
}