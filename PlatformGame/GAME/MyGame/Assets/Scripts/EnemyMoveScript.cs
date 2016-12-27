using UnityEngine;

public class EnemyMoveScript : MonoBehaviour
{
    public static bool IsOnA = false;

    public float MoveSpeed;
    public GameObject Enemy;
    public GameObject EnemyPointA;
    public GameObject EnemyPointB;

    private void Start()
    {
        this.Enemy.transform.position = this.EnemyPointB.transform.position;
    }

    private void FixedUpdate()
    {
        if (IsOnA)
        {
            this.Enemy.transform.eulerAngles = new Vector3(270, 180, 0);
            this.Enemy.transform.position = Vector3.Lerp(this.Enemy.transform.position, this.EnemyPointB.transform.position, Time.deltaTime * MoveSpeed);
        }

        if (!IsOnA)
        {
            this.Enemy.transform.eulerAngles = new Vector3(270, 0, 0);
            this.Enemy.transform.position = Vector3.Lerp(this.Enemy.transform.position, this.EnemyPointA.transform.position, Time.deltaTime * MoveSpeed);           
        }
    }
}