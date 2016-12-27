using UnityEngine;
using System.Collections;

public class MineScript : MonoBehaviour
{
    public ParticleSystem effect;
    public AudioClip MineBoom;

    void Awake()
    {
        effect.emissionRate = 0;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine(Wait());            
        }
    }

    IEnumerator Wait()
    {
        effect.Emit((int)(10000 * Time.deltaTime));
        yield return new WaitForSeconds(0.2f);
        AudioSource.PlayClipAtPoint(MineBoom, Camera.main.transform.position, 1f);
        PlayerHealth.Health -= 50;
        Destroy(this.gameObject);
    }
}