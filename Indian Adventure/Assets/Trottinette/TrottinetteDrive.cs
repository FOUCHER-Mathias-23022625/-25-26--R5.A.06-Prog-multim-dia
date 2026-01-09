using UnityEngine;

public class TrottinetteDrive : MonoBehaviour
{
    public Transform seatPoint;          // Position où le joueur est
    public float speed = 8f;
    public float turnSpeed = 80f;

    private bool playerNearby = false;
    private bool isMounted = false;

    private GameObject player;
    private PlayerControllerSimple playerMovement;
    private Rigidbody rb;

    public ParticleSystem smokeFX;
    public AudioSource engineAudio;
    public float minMoveToPlay = 0.1f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        smokeFX.Stop();
        engineAudio.Stop();
    }

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (!isMounted)
                MonterTrottinette();
            else
                DescendreTrottinette();
        }
    }

    void FixedUpdate()
    {
        if (!isMounted) return;

        float move = Input.GetAxis("Vertical");
        float turn = Input.GetAxis("Horizontal");

        Vector3 moveDirection = transform.forward * move * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveDirection);

        Quaternion turnRotation = Quaternion.Euler(0f, turn * turnSpeed * Time.fixedDeltaTime, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);

        if (isMounted && Mathf.Abs(Input.GetAxis("Vertical")) > minMoveToPlay)
        {
            if (!smokeFX.isPlaying)
                smokeFX.Play();

            if (!engineAudio.isPlaying)
                engineAudio.Play();
        }
        else
        {
            smokeFX.Stop();
            engineAudio.Stop();
        }
    }


    void MonterTrottinette()
    {
        isMounted = true;

        playerMovement.enabled = false;
        player.GetComponent<CharacterController>().enabled = false;

        player.transform.SetParent(transform);
        player.transform.position = seatPoint.position;
        player.transform.rotation = seatPoint.rotation;
    }

    void DescendreTrottinette()
    {
        isMounted = false;

        player.transform.SetParent(null);
        player.GetComponent<CharacterController>().enabled = true;
        playerMovement.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Trigger touché par : " + other.name);

        if (other.CompareTag("Player"))
        {
            //Debug.Log("PLAYER DETECTÉ !");
            playerNearby = true;
            player = other.gameObject;
            playerMovement = player.GetComponent<PlayerControllerSimple>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }

    void OnGUI()
    {
        //GUI.Label(
        //new Rect(20, 20, 300, 40),
        //"TEST UI - Player a coter = " + playerNearby);
        if (playerNearby && !isMounted)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height - 80, 200, 30), "Appuyez sur E");
        }
    }
}
