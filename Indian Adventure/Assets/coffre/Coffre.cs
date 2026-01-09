using UnityEngine;
using TMPro;

public class Coffre : MonoBehaviour
{
    public GameObject texteUI;
    public MoneyCompteur moneyCompteur;
    public GameObject imageNaanHUD;



    private bool joueurProche = false;
    private bool estOuvert = false;

    void Update()
    {
        if (joueurProche && !estOuvert && Input.GetKeyDown(KeyCode.E))
        {
            OuvrirCoffre();
        }
    }

    void OuvrirCoffre()
    {
        if (Iventaire.aLeNaan == true)
        {
            estOuvert = true;

            texteUI.SetActive(false);
            Debug.Log("Le coffre est ouvert !");
            moneyCompteur.AddMoney(100);
            Iventaire.aLeNaan = false;
            imageNaanHUD.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !estOuvert)
        {
            joueurProche = true;
            texteUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            joueurProche = false;
            texteUI.SetActive(false);
        }
    }
}