using UnityEngine;

public class Mover : MonoBehaviour
{
    private void Update()
    {
        transform.position += GameManager.instance.CalculateGameSpeed() * Time.deltaTime * Vector3.left;
    }
}
