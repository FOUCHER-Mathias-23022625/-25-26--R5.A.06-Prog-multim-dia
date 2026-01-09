using UnityEngine;
using UnityEngine.SceneManagement; // Ajoute ceci pour pouvoir redémarrer

public class GameStart : MonoBehaviour
{
    public GameObject menuCanvas;
    public PlayerControllerSimple playerScript;
    public ThirdPersonCameraSimple cameraScript;
    public GameObject gameOverUI;
    public GameObject victoryUI;
    public GameObject MoneyHud;

    private static bool estPremierLancement = true;

    void Start()
    {
        if (estPremierLancement)
        {
            ShowMenu();
        }
        else
        {
            // C'est un restart, on lance le jeu direct
            StartGame();
        }
    }

    public void ShowMenu()
    {
        Mort scriptMort = playerScript.GetComponent<Mort>();
        VictoryTrigger victoire = Object.FindObjectOfType<VictoryTrigger>();
        if (scriptMort != null && playerScript.enabled == false && !estPremierLancement || victoire!= null && victoire.HasWin && !estPremierLancement) // verif dans le cas ou le joeur fais menu principale puis jouer en ayant deja joué une partie et est mort 
        {
            // Si le joueur était mort, on recharge carrement la scene pour le réinitialiser
            RestartGame();
        }
        estPremierLancement = true;
        gameOverUI.SetActive(false);
        victoryUI.SetActive(false);
        MoneyHud.SetActive(false);
        Time.timeScale = 0f;
        menuCanvas.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (playerScript != null) playerScript.enabled = false;
        if (cameraScript != null) cameraScript.enabled = false;
    }

    public void StartGame()
    {
        estPremierLancement = false;
        Time.timeScale = 1f;
        menuCanvas.SetActive(false);
        gameOverUI.SetActive(false); // On cache aussi le Game Over au cas ou

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        MoneyHud.SetActive(true);

        if (playerScript != null) playerScript.enabled = true;
        if (cameraScript != null) cameraScript.enabled = true;


    }

    public void RestartGame()
    {
        estPremierLancement = false;
        Time.timeScale = 1f;
        MoneyHud.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}