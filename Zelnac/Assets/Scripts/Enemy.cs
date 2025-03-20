using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int vida = 50;
    public void ReceberDano(int dano)
    {
        vida -= dano;
        Debug.Log("Inimigo recebeu " + dano + " de dano! Vida restante: " + vida);

        if (vida <= 0)
        {
            Morrer();
        }
    }

    public virtual void Morrer()
    {
        Debug.Log("Inimigo morreu!");
        Destroy(gameObject); 
    }
}
