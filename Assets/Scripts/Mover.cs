using UnityEngine;

public class Mover : MonoBehaviour
{
    [Header("Settings")]
    public float moveSpeed;

    private Vector3 speed;

    private void Start()
    {
        speed = Vector3.left * moveSpeed;
    }

    private void Update()
    {
        transform.position += speed * Time.deltaTime;
    }
}
