using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerControllerSimple : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpSpeed = 8f;
    public float gravity = 20f;
    public Transform cameraTransform; // Camera pour la direction

    public ParticleSystem Particules;

    private CharacterController controller;
    private Vector3 velocity;
    private Animator animator; // Pour animation

    public AudioSource footstepAudio; //son
    public AudioClip footstepClip;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>(); // Recupere l'Animator
        if (Particules != null) Particules.Stop();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = Vector3.zero;

        if (controller.isGrounded)
        {
            // Direction camera
            Vector3 forward = cameraTransform.forward;
            Vector3 right = cameraTransform.right;
            forward.y = 0;
            right.y = 0;

            move = (forward.normalized * v + right.normalized * h).normalized;

            // Mouvement
            velocity = move * moveSpeed;

            // Rotation du joueur
            if (move.magnitude > 0.1f)
                transform.rotation = Quaternion.LookRotation(move);

            // Saut
            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = jumpSpeed;
                animator.SetTrigger("Jump");
                if (Particules != null) Particules.Stop();
            }

            // Roulade
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                animator.SetTrigger("Roll"); 
            }

            // parametre Speed pour stand/Run
            animator.SetFloat("Speed", move.magnitude);
        }
        else
        {
            // Si en l'air, on garde la gravite
            velocity.y -= gravity * Time.deltaTime;
        }

        // Gravite
        velocity.y -= gravity * Time.deltaTime;

        // Déplacement final
        controller.Move(velocity * Time.deltaTime);

        if (controller.isGrounded && move.magnitude > 0.1f && !footstepAudio.isPlaying)
        {
            if (Particules != null && !Particules.isPlaying)
            {
                Particules.Play();
            }
            footstepAudio.clip = footstepClip;
            footstepAudio.Play();
        }

        if (move.magnitude < 0.1f)
        {
            footstepAudio.Stop();
            Particules.Stop();
        }
    }
}
