using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    public static bool IsOnA = false;

    public float MoveSpeed;
    public GameObject Platform;
    public GameObject PointA;
    public GameObject PointB;

    private void Start()
    {
        this.Platform.transform.position = this.PointA.transform.position;
    }

    private void FixedUpdate()
    {
        if (IsOnA)
        {
            this.Platform.transform.position = Vector3.Lerp(this.Platform.transform.position, this.PointB.transform.position, Time.deltaTime * MoveSpeed);
        }

        if (!IsOnA)
        {
            this.Platform.transform.position = Vector3.Lerp(this.Platform.transform.position, this.PointA.transform.position, Time.deltaTime * MoveSpeed);
        }
    }
}