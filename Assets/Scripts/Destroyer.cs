using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.x < -13)
        {
            Destroy(gameObject);
        }
    }
}
