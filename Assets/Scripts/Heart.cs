using UnityEngine;

public class Heart : MonoBehaviour
{
    public Sprite onHeart;
    public Sprite offHeart;
    public SpriteRenderer spriteRenderer;
    public int liveNumber;

    private void Update()
    {
        if (GameManager.instance.lives >= liveNumber)
        {
            spriteRenderer.sprite = onHeart;
        }
        else
        {
            spriteRenderer.sprite = offHeart;
        }
    }
}
