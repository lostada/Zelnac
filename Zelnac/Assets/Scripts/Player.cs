using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Player : MonoBehaviour
{
    public Item espada;
    public Item poteDeVida;
    private Item itemEquipada;
    public ItemDisplay itemDisplay;

    public int vidaMaxima = 100;  // Vida máxima do player
    public int vidaAtual;  // Vida atual do player

    void Start()
    {
        vidaAtual = vidaMaxima;  // Inicializa a vida com o valor máximo
        itemEquipada = espada;  // Inicializa com a espada equipada
        itemDisplay.UpdateItemDisplay(itemEquipada);  // Atualiza a UI do item exibido
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AlternarItens();  // Alterna os itens quando "Q" é pressionado
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            UsarItem();  // Chama o método para usar o item
        }
    }

    void AlternarItens()
    {
        // Alterna entre a espada e o pote de vida
        if (itemEquipada == espada)
        {
            itemEquipada = poteDeVida;
        }
        else
        {
            itemEquipada = espada;
        }

        itemDisplay.UpdateItemDisplay(itemEquipada);  // Atualiza a UI para o novo item equipado
    }

    void UsarItem()
    {
        if (itemEquipada != null)
        {
            itemEquipada.Use();  // Chama o método 'Use' do item atualmente equipado
        }
    }

    // Método para restaurar vida
    public void RestaurarVida(int quantidade)
    {
        vidaAtual = Mathf.Min(vidaAtual + quantidade, vidaMaxima);  // Garante que a vida não ultrapasse o máximo
        Debug.Log("Vida atual: " + vidaAtual);
    }
}
