using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PoteDeVida : Item
{
    public int cura = 20;

    void Start()
    {
        itemName = "Pote de Vida";
    }

    public override void Use()
    {
        Debug.Log("Pote de Vida usado!");
        FindObjectOfType<Player>().RestaurarVida(cura); 
    }

    public override void Equip()
    {
        Debug.Log("Pote de Vida equipado!");
    }
}
