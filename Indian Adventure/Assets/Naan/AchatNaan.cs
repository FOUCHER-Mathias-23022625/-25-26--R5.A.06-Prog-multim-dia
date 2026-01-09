using UnityEngine;

public class AchatNaan : MonoBehaviour
{
    public GameObject messageUI; 
    public GameObject imageNaanHUD; 
    public int prix = 5;

    private bool joueurEstProche = false;
    private bool dejaVendu = false;

    void Update()
    {
        if (joueurEstProche && !dejaVendu && Input.GetKeyDown(KeyCode.E))
        {
            if (MoneyCompteur.instance.money >= prix)
            {
                MoneyCompteur.instance.AddMoney(-prix);
                imageNaanHUD.SetActive(true);
                Iventaire.aLeNaan = true;
                dejaVendu = true;
                messageUI.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !dejaVendu)
        {
            joueurEstProche = true;
            messageUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            joueurEstProche = false;
            messageUI.SetActive(false);
        }
    }
}