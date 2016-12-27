using UnityEngine;

public class GunsLookAt : MonoBehaviour
{
    public float Forse = 0;
    public float fireRate = 0f;
    public GameObject Shell;
    public GameObject GunOne;
    public GameObject GunTwo;
    public AudioClip ShotSound;

    private AudioSource audioSource;
    private float nextFire = 0;
    private bool isInRange = false;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerStay(Collider other)
    {
        if (isInRange && other.gameObject.tag == "Player")
        {
            transform.LookAt(other.transform.position);
            transform.Rotate(90f, 0f, 0f);

            if (Time.time > nextFire)
            {
                audioSource.clip = ShotSound;
                audioSource.Play();
                nextFire = Time.time + fireRate;
                GameObject shell = GameObject.Instantiate(Shell);
                shell.transform.position = GunOne.transform.position;
                shell.transform.rotation = GunOne.transform.rotation;
                shell.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0f, 0f, Forse), ForceMode.Impulse);
                shell.AddComponent<ShellLifeTime>();

                shell = Instantiate(Shell);
                shell.transform.position = GunTwo.transform.position;
                shell.transform.rotation = GunTwo.transform.rotation;
                shell.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0f, 0f, Forse), ForceMode.Impulse);
                shell.AddComponent<ShellLifeTime>();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInRange = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInRange = true;
        }
    }
}