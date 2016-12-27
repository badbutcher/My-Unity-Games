using UnityEngine;

public class WoodSounds : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] Sounds;

    void Awake()
    {
        this.audioSource = this.GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Platform" || coll.gameObject.tag == "Ground")
        {
            this.audioSource.PlayOneShot(this.Sounds[Random.Range(0, this.Sounds.Length)]);
        }
    }
}