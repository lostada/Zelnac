using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int vida = 50; // Vida do inimigo

    // M�todo para receber dano
    public void ReceberDano(int dano)
    {
        vida -= dano;
        Debug.Log("Inimigo recebeu " + dano + " de dano! Vida restante: " + vida);

        if (vida <= 0)
        {
            Morrer();
        }
    }

    // M�todo de morte do inimigo, agora marcado como virtual para permitir sobrescrita
    public virtual void Morrer()
    {
        Debug.Log("Inimigo morreu!");
        Destroy(gameObject);  // Destroi o objeto inimigo
    }
}
