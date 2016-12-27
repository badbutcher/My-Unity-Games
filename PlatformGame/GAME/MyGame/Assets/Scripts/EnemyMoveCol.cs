using UnityEngine;

public class EnemyMoveCol : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "EnemyA")
        {
            EnemyMoveScript.IsOnA = true;
        }

        if (col.gameObject.tag == "EnemyB")
        {
            EnemyMoveScript.IsOnA = false;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            //MonoBehaviour.Destroy(col.gameObject);
            MonoBehaviour.Destroy(this.gameObject);
        }
    }
}