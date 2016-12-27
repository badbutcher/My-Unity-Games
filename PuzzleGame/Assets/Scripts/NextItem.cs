using UnityEngine;

public class NextItem : MonoBehaviour
{
    void Update()
    {
        this.OnMouseDrag();
    }

    void OnMouseDrag()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }
}