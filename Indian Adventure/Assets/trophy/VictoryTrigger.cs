using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryTrigger : MonoBehaviour
{
    public GameObject victoryUI;
    public bool HasWin = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Win();
        }
    }

    void Win()
    {
        Debug.Log("VOUS AVEZ GAGNERRRRRR ");
        HasWin = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        victoryUI.SetActive(true);
        Time.timeScale = 0f; // Met le jeu en pause
    }

}