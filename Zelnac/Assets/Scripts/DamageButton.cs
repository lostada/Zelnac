using UnityEngine;

public class DamageButton : MonoBehaviour
{
    public int dano = 10;
    private BossHealth bossHealth;

    void Start()
    {
        bossHealth = FindObjectOfType<BossHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Se o jogador tocar no bot�o
        {
            if (bossHealth != null)
            {
                bossHealth.ReceberDano(dano);
                Debug.Log("Bot�o ativado! O chefe recebeu " + dano + " de dano.");
            }
        }
    }
}
