using UnityEngine;

public class PlatformMovePlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        col.transform.parent = gameObject.transform;
    }

    private void OnTriggerExit(Collider col)
    {
        col.transform.parent = null;
    }
}