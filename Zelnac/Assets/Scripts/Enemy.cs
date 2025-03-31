using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject pota;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }
    
    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
        pota.SetActive(true);
    }
}

public class Dummy : Enemy
{
    protected override void Die()
    {
        Debug.Log("Matou seu unico amigo aqui.");
    }
}
