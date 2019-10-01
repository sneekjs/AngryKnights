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
}
