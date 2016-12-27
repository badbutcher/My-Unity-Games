using UnityEngine;

public class UIRotator : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0, 0, 45 * Time.deltaTime);
    }
}