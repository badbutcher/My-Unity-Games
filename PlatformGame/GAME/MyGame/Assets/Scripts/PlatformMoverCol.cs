using UnityEngine;

public class PlatformMoverCol : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "PlatformA")
        {
            PlatformMover.IsOnA = true;
        }

        if (col.gameObject.tag == "PlatformB")
        {
            PlatformMover.IsOnA = false;
        }
    }
}