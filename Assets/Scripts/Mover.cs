using UnityEngine;

public class Mover : MonoBehaviour
{
    [Header("Settings")]
    public float moveSpeed;

    private Vector3 _moveVector;

    private void Start()
    {
        _moveVector = Vector3.left * moveSpeed;
    }

    private void Update()
    {
        transform.position += _moveVector * Time.deltaTime;
    }
}
