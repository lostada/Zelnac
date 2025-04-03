using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 60;
    private int currentHealth;
    public Slider healthSlider; // Barra de vida do chefe
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        spriteRenderer = GetComponent<SpriteRenderer>(); // Pega o sprite do chefe
    }

    public void ReceberDano(int dano)
    {
        currentHealth -= dano;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        AtualizarVida();

        StartCoroutine(TomarDanoVisual()); // Ativa o efeito de dano

        if (currentHealth <= 0)
        {
            Morrer();
        }
    }

    IEnumerator TomarDanoVisual()
    {
        spriteRenderer.color = Color.red; // Fica vermelho
        yield return new WaitForSeconds(0.25f); // Espera 0.25s
        spriteRenderer.color = Color.white; // Volta ao normal
    }

    void AtualizarVida()
    {
        healthSlider.value = currentHealth;
    }

    void Morrer()
    {
        Debug.Log("O chefe foi derrotado!");
        Destroy(gameObject);
    }
}
