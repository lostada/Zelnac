using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;


public class Espada : Item
{
    void Start()
    {
        itemName = "Espada";  
    }

    public override void Use()
    {
        Debug.Log("Espada usada!");
    }
}
