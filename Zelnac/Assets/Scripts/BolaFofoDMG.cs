using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaFofoDMG : MonoBehaviour
{
    Vector3 directione;
    public int damage = 10;
    public float speed = 5f; 

    void Update()
    {
        transform.position += directione * speed * Time.deltaTime;
    }

    public void Direcao(Vector3 direction)
    {
        directione = direction.normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) // Se colidir com um inimigo normal
        {
            InimigoVida enemy = collision.GetComponent<InimigoVida>();
            if (enemy != null)
            {
                enemy.ReceberDano(damage);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("Inimigo não tem script InimigoVida!");
            }
        }
        else if (collision.CompareTag("Boss")) // Se colidir com o chefe
        {
            BossHealth boss = collision.GetComponent<BossHealth>();
            if (boss != null)
            {
                boss.ReceberDano(damage);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("Chefe não tem script BossHealth!");
            }
        }
        else
        {
            Debug.Log("Bola de fogo colidiu com: " + collision.gameObject.name);
        }
    }
}
