using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Player : MonoBehaviour
{
    public Item espada;
    public Item poteDeVida;
    private Item itemEquipada;
    public ItemDisplay itemDisplay;

    public int vidaMaxima = 100;
    public int vidaAtual;

    void Start()
    {
        vidaAtual = vidaMaxima; 
        itemEquipada = espada; 
        itemDisplay.UpdateItemDisplay(itemEquipada); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AlternarItens(); 
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            UsarItem();
        }
    }

    void AlternarItens()
    {
        if (itemEquipada == espada)
        {
            itemEquipada = poteDeVida;
        }
        else
        {
            itemEquipada = espada;
        }

        itemDisplay.UpdateItemDisplay(itemEquipada);  
    }

    void UsarItem()
    {
        if (itemEquipada != null)
        {
            itemEquipada.Use();  
        }
    }

    public void RestaurarVida(int quantidade)
    {
        vidaAtual = Mathf.Min(vidaAtual + quantidade, vidaMaxima);
        Debug.Log("Vida atual: " + vidaAtual);
    }
}
