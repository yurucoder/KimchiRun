using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Settings")]
    public float JumpForce;

    [Header("References")]
    public Rigidbody2D PlayerRigidBody;
    public Animator PlayerAnimator;
    public BoxCollider2D PlayerCollider;

    private bool isGrounded = true;
    private int lives = 3;
    private bool isInvincible = false;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!isInvincible)
            {
                Destroy(collision.gameObject);
                Hit();
            }
        }
        else if (collision.gameObject.CompareTag("Food"))
        {
            Destroy(collision.gameObject);
            if (lives < 3)
            {
                lives += 1;
            }
        }
        else if (collision.gameObject.CompareTag("Golden"))
        {
            Destroy(collision.gameObject);
            isInvincible = true;
            Invoke(nameof(StopInvincible), 5f);
        }
    }

    private void Hit()
    {
        lives -= 1;
        if (lives <= 0)
        {
            KillPlayer();
        }
    }

    private void StopInvincible()
    {
        isInvincible = false;
    }

    private void KillPlayer()
    {
        PlayerCollider.enabled = false;
        PlayerAnimator.enabled = false;
        PlayerRigidBody.AddForceY(JumpForce, ForceMode2D.Impulse);
    }
}
