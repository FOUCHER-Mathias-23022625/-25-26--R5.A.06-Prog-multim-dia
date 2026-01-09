using UnityEngine;

public class Ennemi : MonoBehaviour
{
    public float amplitude = 5f; // Distance gauche/droite
    public float vitesse = 2f;
    private Vector3 positionDepart;

    public AudioClip sonMortEnnemi;
    public GameObject objetTrotinette;
    public GameObject Player;

    void Start()
    {
        positionDepart = transform.position;
    }

    void Update()
    {
        // Calcul du mouvement sur l'axe X
        float nouveauX = positionDepart.x + Mathf.Sin(Time.time * vitesse) * amplitude;
        transform.position = new Vector3(nouveauX, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        // 1. Si on touche la trottinette
        if (other.gameObject == objetTrotinette)
        {
            MortEnnemi();
            return;
        }

        // 2. Si on touche le joueur
        if (other.CompareTag("Player"))
        {
            Mort scriptMort = other.GetComponent<Mort>();
            if (scriptMort != null)
            {
                scriptMort.Die();
            }

        }
    }

    void MortEnnemi()
    {
        if (sonMortEnnemi != null)
        {
            AudioSource.PlayClipAtPoint(sonMortEnnemi, transform.position);
        }

        Debug.Log("L'ennemi est écrasé par la trottinette !");
        Destroy(gameObject);
    }
}