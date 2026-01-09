using UnityEngine;

public class Mort : MonoBehaviour
{
    public GameObject gameOverUI;
    public AudioSource deathAudio;
    public AudioClip deathClip;

    private Animator animator;
    private PlayerControllerSimple playerMovement;
    private CharacterController controller;
    private bool isDead = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerControllerSimple>();
        controller = GetComponent<CharacterController>();

        gameOverUI.SetActive(false);
    }

    public void Die()
    {
        if (isDead) return;
        isDead = true;

        // Stop le joueur
        playerMovement.enabled = false;
        controller.enabled = false;

        // Son de mort
        if (deathAudio != null && deathClip != null)
        {
            deathAudio.clip = deathClip;
            deathAudio.Play();
        }

        // Animation de mort
        animator.SetTrigger("Die");

        // Afficher le Game Over
        Invoke(nameof(ShowGameOver), 0.5f);
    }

    void ShowGameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
