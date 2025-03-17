using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class PoteDeVida : Item
{
    void Start()
    {
        itemName = "Pote de Vida";
    }

    public override void Use()
    {        
        Debug.Log("Pote de Vida usado!");
    }
}
