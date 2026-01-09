using UnityEngine;

public class TrophyAnimation : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float floatAmplitude = 0.5f;
    public float floatFrequency = 1f;

    private Vector3 startPos;

    void Start() => startPos = transform.position;

    void Update()
    {
        // Rotation sur l'axe Y (tourne sur lui-même)
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        // Mouvement de haut en bas (Sinus)
        float newY = startPos.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}