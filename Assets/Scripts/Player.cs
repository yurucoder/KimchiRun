using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Settings")]
    public float jumpForce;

    [Header("References")]
    public Rigidbody2D playerRigidBody;
    public Animator playerAnimator;
    public BoxCollider2D playerCollider;

    private bool _isGrounded = true;
    private bool _isInvincible = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            playerRigidBody.AddForceY(jumpForce, ForceMode2D.Impulse);
            playerAnimator.SetInteger("state", 1);
            _isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Platform")
        {
            if (!_isGrounded)
            {
                playerAnimator.SetInteger("state", 2);
            }

            _isGrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!_isInvincible)
            {
                Destroy(collision.gameObject);
                GameManager.instance.lives -= 1;
            }
        }
        else if (collision.gameObject.CompareTag("Food"))
        {
            Destroy(collision.gameObject);
            if (GameManager.instance.lives < 3)
            {
                GameManager.instance.lives += 1;
            }
        }
        else if (collision.gameObject.CompareTag("Golden"))
        {
            Destroy(collision.gameObject);
            _isInvincible = true;
            Invoke(nameof(StopInvincible), 5f);
        }
    }

    private void StopInvincible()
    {
        _isInvincible = false;
    }

    public void KillPlayer()
    {
        playerCollider.enabled = false;
        playerAnimator.enabled = false;
        playerRigidBody.AddForceY(jumpForce, ForceMode2D.Impulse);
    }
}
