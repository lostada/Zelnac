using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDano : MonoBehaviour
{
    PlayerStatus statusPlayer;
    Coroutine attackRoutine;
    public int damage;
    public int attackCooldown = 2;

    void Start()
    {
        statusPlayer = FindObjectOfType<PlayerStatus>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && attackRoutine == null)
        {
            attackRoutine = StartCoroutine(Attack());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && attackRoutine != null)
        {
            StopCoroutine(attackRoutine);
            attackRoutine = null;
        }
    }

    IEnumerator Attack()
    {
        while (true)
        {
            statusPlayer.TakeDmg(damage);
            yield return new WaitForSeconds(2);
        }
    }
}