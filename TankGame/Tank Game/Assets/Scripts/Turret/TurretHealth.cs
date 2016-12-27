using System.Collections;
using UnityEngine;

public class TurretHealth : MonoBehaviour
{
    private float Health = 300;
    public static float DamageFromPlayer;
    public static float TurretMoneyForKilling = 20;
    public static float TurretScoreForKilling = 50;
    public AudioClip GetDestroyedSound;
    public AudioClip GetHitSound;
    public ParticleSystem effect;
    public Animator ani;

    void Start()
    {
        ani.enabled = false;
    }

    void Awake()
    {
        effect.emissionRate = 0;
    }

    void Update()
    {
        if (Health <= 0)
        {
            ani.enabled = true;
            StartCoroutine(Wait());
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "PlayerShot")
        {
            AudioSource.PlayClipAtPoint(GetHitSound, Camera.main.transform.position, 0.9f);
            effect.Emit((int)(10000 * Time.deltaTime));
            Health -= DamageFromPlayer;
            Destroy(col.gameObject);
        }
    }

    IEnumerator Wait()
    {
        effect.Emit((int)(30000 * Time.deltaTime));
        yield return new WaitForSeconds(0.66f);
        AudioSource.PlayClipAtPoint(GetDestroyedSound, Camera.main.transform.position, 0.5f);
        MoneyManager.Coins += TurretMoneyForKilling;
        MoneyManager.Score += TurretScoreForKilling;
        Destroy(this.gameObject);
    }
}