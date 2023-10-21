using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50;

    public void Takedamage(float amount)
    {
        health -= amount;
        if(health <=0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
