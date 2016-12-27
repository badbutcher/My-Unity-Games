using UnityEngine;

public class TurretShot : MonoBehaviour
{
    public float Forse = 0;
    public float FireRate = 0f;
    public GameObject Shell;
    public GameObject ShotFrom;
    public AudioClip ShotSound;

    private AudioSource source;
    private bool inRange;

    private float nextFire = 0;

    private void Awake()
    {
        this.source = this.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Time.time > this.nextFire && this.inRange)
        {
            this.source.PlayOneShot(this.ShotSound, 1);
            this.nextFire = Time.time + this.FireRate;
            GameObject shell = GameObject.Instantiate(this.Shell);
            shell.transform.position = this.ShotFrom.transform.position;
            shell.transform.rotation = this.ShotFrom.transform.rotation;
            shell.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0f, 0f, this.Forse), ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            this.inRange = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            this.inRange = false;
        }
    }
}