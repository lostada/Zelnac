using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PoteDeVida : Item
{
    public int cura = 20;  // Quantidade de vida restaurada pelo pote de vida

    void Start()
    {
        itemName = "Pote de Vida";
    }

    public override void Use()
    {
        // Aqui chamamos o Player para restaurar a vida diretamente
        Debug.Log("Pote de Vida usado!");
        FindObjectOfType<Player>().RestaurarVida(cura);  // Chama o m�todo no Player para restaurar a vida
    }

    public override void Equip()
    {
        // Se necess�rio, pode-se adicionar alguma l�gica para equipar o item.
        Debug.Log("Pote de Vida equipado!");
    }
}
