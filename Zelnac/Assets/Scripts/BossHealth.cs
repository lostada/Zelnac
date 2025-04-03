using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 60;
    private int currentHealth;
    public Slider healthSlider; // Barra de vida do chefe

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth; // Define o valor máximo da barra
        healthSlider.value = currentHealth; // Inicia cheia
    }

    public void ReceberDano(int dano)
    {
        currentHealth -= dano;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Garante que a vida não seja negativa
        AtualizarVida();

        if (currentHealth <= 0)
        {
            Morrer();
        }
    }

    void AtualizarVida()
    {
        healthSlider.value = currentHealth; // Atualiza a barra de vida
    }

    void Morrer()
    {
        Debug.Log("O chefe foi derrotado!");
        Destroy(gameObject);
    }
}
