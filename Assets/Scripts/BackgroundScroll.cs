using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [Header("Settings")] [Tooltip("How fast should the texture scroll?")]
    public float scrollSpeed;

    [Header("References")] public MeshRenderer meshRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, 0);
    }
}