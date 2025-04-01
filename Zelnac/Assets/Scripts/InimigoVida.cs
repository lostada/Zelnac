using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class InimigoVida : MonoBehaviour
{

    public GameObject dialogo;
    public GameObject enemy;
    public GameObject porta;
    public GameObject porta1;
    public int vida = 90; 

    public void ReceberDano(int dano)
    {
        vida -= dano;
        Debug.Log("ele ta com" + vida);

        if (vida <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        Debug.Log("Inimigo derrotado!");
        enemy.SetActive(false);
        dialogo.SetActive(true);
        porta.SetActive(true);
        porta1.SetActive(true);
        Debug.Log("particulamaneira");
        
}
}
