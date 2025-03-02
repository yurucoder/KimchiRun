using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Settings")]
    public float JumpForce;

    [Header("References")]
    public Rigidbody2D PlayerRigidBody;
    public Animator PlayerAnimator;

    private bool isGrounded = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            PlayerRigidBody.AddForceY(JumpForce, ForceMode2D.Impulse);
            PlayerAnimator.SetInteger("state", 1);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Platform")
        {
            if (!isGrounded)
            {
                PlayerAnimator.SetInteger("state", 2);
            }

            isGrounded = true;
        }
    }
}
