using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public static float moveSpeed = 30;
    public static float rotateSpeed = 30;
    public Rigidbody rb;
    public AudioClip MoveSound;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.Translate(0f, 0f, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
        transform.Rotate(0f, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime, 0f);
        rb.AddForce(Vector3.up * -80000);
        audioSource.clip = MoveSound;

        if (Input.GetButton("Vertical"))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else if (Input.GetButton("Horizontal"))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }
}