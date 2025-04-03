using System.Collections;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public int dano = 10;
    public float cooldown = 0.7f;
    private bool podeAtacar = true;
    private InimigoVida enemy;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>(); // Pegando o Animator da espada
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemy = collision.GetComponent<InimigoVida>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemy = null;
        }
    }

    public void Attack()
    {
        if (podeAtacar)
        {
            StartCoroutine(Atacar());
        }
    }

    private IEnumerator Atacar()
    {
        podeAtacar = false;
        anim.SetBool("IsAttacking", true); // Ativa a animação

        if (enemy != null)
        {
            enemy.ReceberDano(dano);
        }

        yield return new WaitForSeconds(0.7f); // Tempo do ataque

        anim.SetBool("IsAttacking", false); // Volta para Idle
        yield return new WaitForSeconds(cooldown);
        podeAtacar = true;
    }
}
