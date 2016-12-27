using UnityEngine;
using System.Collections;

public class EnemyTankHealth : MonoBehaviour
{
    private float Health = 400;
    public static float EnemyTankDamageFromPlayer;
    public static float EnemyTankMoneyForKilling = 50;
    public static float EnemyTankScoreForKilling = 120;
    public AudioClip GetDestroyedSound;
    public AudioClip GetHitSound;
    public ParticleSystem effect;

    void Awake()
    {
        effect.emissionRate = 0;
    }

    void Update()
    {
        if (Health <= 0)
        {
            StartCoroutine(Wait());
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "PlayerShot")
        {
            AudioSource.PlayClipAtPoint(GetHitSound, Camera.main.transform.position, 0.4f);
            effect.Emit((int)(10000 * Time.deltaTime));
            Health -= EnemyTankDamageFromPlayer;
            Destroy(col.gameObject);
        }
    }

    IEnumerator Wait()
    {
        effect.Emit((int)(30000 * Time.deltaTime));
        yield return new WaitForSeconds(0.1f);
        AudioSource.PlayClipAtPoint(GetDestroyedSound, Camera.main.transform.position, 0.9f);
        MoneyManager.Coins += EnemyTankMoneyForKilling;
        MoneyManager.Score += EnemyTankScoreForKilling;
        Destroy(this.gameObject);
    }
}