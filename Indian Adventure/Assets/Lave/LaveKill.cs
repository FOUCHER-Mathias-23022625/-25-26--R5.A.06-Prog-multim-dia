using UnityEngine;

public class LaveKill : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Mort death = other.GetComponent<Mort>();
            if (death != null)
                death.Die();
        }
    }
}