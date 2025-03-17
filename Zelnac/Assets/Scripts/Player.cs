using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Player : MonoBehaviour
{
    public Item espada;      
    public Item poteDeVida;   
    private Item itemEquipada;
    public ItemDisplay itemDisplay; 

    void Start()
    {
        itemEquipada = espada;  
        itemDisplay.UpdateItemDisplay(itemEquipada);  
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            AlternarItens();
        }

        if (Input.GetKeyDown(KeyCode.E)) 
        {
            itemDisplay.UseItem();  
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
}
