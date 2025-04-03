using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 60;
    private int currentHealth;
    public Image[] healthImages; // Imagens da barra de vida do chefe

    void Start()
    {
        currentHealth = maxHealth;
        AtualizarVida();
    }

    public void ReceberDano(int dano)
    {
        currentHealth -= dano;
        AtualizarVida();

        if (currentHealth <= 0)
        {
            Morrer();
        }
    }

    void AtualizarVida()
    {
        int vidaPorImagem = maxHealth / healthImages.Length;
        for (int i = 0; i < healthImages.Length; i++)
        {
            if (currentHealth >= (i + 1) * vidaPorImagem)
                healthImages[i].enabled = true;
            else
                healthImages[i].enabled = false;
        }
    }

    void Morrer()
    {
        Debug.Log("O chefe foi derrotado!");
        Destroy(gameObject);
    }
}