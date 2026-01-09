using UnityEngine;
using TMPro; 

public class Teleporteur : MonoBehaviour
{
    public GameObject texteTeleport;
    public Transform joueur;         
    public Vector3 destination = new Vector3(-45.71267f, 0.23f, 4f);

    private bool peutTeleporter = false;

    void Start()
    {
        if (texteTeleport != null) texteTeleport.SetActive(false);
    }

    void Update()
    {
        // Si le joueur est dans la zone et appuie sur E
        if (peutTeleporter && Input.GetKeyDown(KeyCode.E))
        {
            Teleporter();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            peutTeleporter = true;
            texteTeleport.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            peutTeleporter = false;
            texteTeleport.SetActive(false);
        }
    }

    void Teleporter()
    {

        CharacterController cc = joueur.GetComponent<CharacterController>();
        if (cc != null) cc.enabled = false;

        joueur.position = destination;

        if (cc != null) cc.enabled = true;

        // cacher le texte après la tp
        texteTeleport.SetActive(false);
        peutTeleporter = false;
    }
}