using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BreakableObject : MonoBehaviour
{
    public int health;

    public List<Sprite> sprites = new List<Sprite>();

    public abstract void Break();

    public virtual void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Break();
        }
    }
}
