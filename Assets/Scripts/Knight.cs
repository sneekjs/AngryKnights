using UnityEngine;
public class Knight : BreakableObject
{
    public override void Break()
    {
        GameManager.Instance.KnightsRemaining--;
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball") && health > 0)
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
            TakeDamage(1);
            sr.sprite = sprites[0];
        }
    }
}
