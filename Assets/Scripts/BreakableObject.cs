using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BreakableObject : MonoBehaviour
{
    public int health;

    public List<Sprite> sprites = new List<Sprite>();

    protected SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public abstract void Break();

    public virtual void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Break();
            return;
        }
        sr.sprite = sprites[health];
    }
}
