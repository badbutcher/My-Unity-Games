using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject EnemyTurret;
    public GameObject EnemyTank;

    private Vector3 newPos;
    private Vector3 startPos;
    private float difficulty = 1f;
    private float progress = 0f;

    void Start()
    {
        SpawnPoint();
    }

    void Update()
    {
        transform.position = Vector3.Lerp(startPos, newPos, progress);

        progress += Time.deltaTime * difficulty;

        if (progress >= 3f && difficulty <= 3)
        {
            Instantiate(EnemyTurret, this.transform.position, Quaternion.identity);
            difficulty += 0.05f;
            SpawnPoint();
        }
        if (difficulty >= 3f && progress >=4)
        {
            Instantiate(EnemyTank, this.transform.position, Quaternion.identity);
            difficulty += 0.01f;
            SpawnPoint();
        }
    }

    void SpawnPoint()
    {
        startPos = transform.position;
        newPos = new Vector3(Random.Range(200f, 800f), 2, Random.Range(200f, 800f));
        progress = 0f;
    }
}