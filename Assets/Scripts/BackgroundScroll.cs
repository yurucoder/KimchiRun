using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [Header("Settings")]
    public float scrollSpeed;

    [Header("References")]
    public MeshRenderer meshRenderer;

    private Vector2 _bgVector;

    private void Update()
    {
        _bgVector.Set(scrollSpeed * Time.deltaTime, 0);
        meshRenderer.material.mainTextureOffset += _bgVector;
    }
}
