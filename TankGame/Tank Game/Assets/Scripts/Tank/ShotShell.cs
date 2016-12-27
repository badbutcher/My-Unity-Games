using UnityEngine;

public class ShotShell : MonoBehaviour
{
    public float Forse = 0;
    public static float fireRate = 1.5f;
    public GameObject Shell;
    public GameObject ShotFrom;
    public AudioClip ShorEffect;

    private AudioSource audioSource;
    private float nextFire = 0;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Time.timeScale == 1)
        {
            if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
            {
                audioSource.clip = ShorEffect;
                audioSource.Play();
                nextFire = Time.time + fireRate;
                GameObject shell = GameObject.Instantiate(Shell);
                shell.transform.position = ShotFrom.transform.position;
                shell.transform.rotation = ShotFrom.transform.rotation;
                shell.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0f, 0f, Forse), ForceMode.Impulse);
                shell.AddComponent<ShellLifeTime>();
            }
        }
    }
}