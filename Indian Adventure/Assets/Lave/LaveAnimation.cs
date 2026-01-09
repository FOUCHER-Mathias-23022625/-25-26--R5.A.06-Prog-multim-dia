using UnityEngine;

public class LaveAnimation : MonoBehaviour
{
    public float scrollSpeedX = 0.1f;
    public float scrollSpeedY = 0.1f;

    private Renderer rend;
    private Vector2 offset;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        offset += new Vector2(scrollSpeedX, scrollSpeedY) * Time.deltaTime;

        rend.material.SetTextureOffset("_MainTex", offset);
        rend.material.SetTextureOffset("_BumpMap", offset); // Sert pour la normal map
    }
}

