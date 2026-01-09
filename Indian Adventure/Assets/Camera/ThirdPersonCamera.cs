using UnityEngine;

public class ThirdPersonCameraSimple : MonoBehaviour
{
    public Transform target;      // Joueur
    public float distance = 4f;   // Distance camera / joueur
    public float height = 2f;     // Hauteurcamera
    public float rotationSpeed = 100f; // Sensibilite souris
    private float angle = 0f;     // Angle autour du joueur

    void Start()
    {
        // On bloque le curseur pour la caméra
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Mouvement horizontal de la souris
        float mouseX = Input.GetAxis("Mouse X");
        angle += mouseX * rotationSpeed * Time.deltaTime;

        // Calcul position de la caméra
        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        Vector3 offset = rotation * new Vector3(0, height, -distance);

        transform.position = target.position + offset;
        transform.LookAt(target.position + Vector3.up * height);
    }
}
