using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class InimigoVida : MonoBehaviour
{
    public int vida = 50; // Vida inicial do inimigo

    public void ReceberDano(int dano)
    {
        vida -= dano;
        Debug.Log("Inimigo recebeu dano! Vida restante: " + vida);

        if (vida <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        Debug.Log("Inimigo derrotado!");
        Destroy(gameObject); // Remove o inimigo da cena
    }
}
