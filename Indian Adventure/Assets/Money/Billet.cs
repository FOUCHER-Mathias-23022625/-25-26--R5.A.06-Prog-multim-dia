using UnityEngine;

public class BilletPickup : MonoBehaviour
{
    public int value = 1;
    public AudioClip pickupSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MoneyCompteur.instance.AddMoney(value);
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            Destroy(gameObject);
        }
    }
}
