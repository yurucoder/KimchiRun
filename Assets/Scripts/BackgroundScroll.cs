using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("How fast should the texture scroll?")]
    public float scrollSpeed;

    [Header("References")]
    public MeshRenderer meshRenderer;

    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, 0);
    }
}