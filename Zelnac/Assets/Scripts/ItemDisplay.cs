using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class ItemDisplay : MonoBehaviour
{
    public Image espadaIcon; 
    public Image curaIcon;    
    private Item itemEquipada;
    void Start()
    {
       
        espadaIcon.gameObject.SetActive(false);
        curaIcon.gameObject.SetActive(false);
    }
    public void UpdateItemDisplay(Item item)
    {
        
        itemEquipada = item;

        
        if (itemEquipada is Espada)
        {
            espadaIcon.gameObject.SetActive(true);
            curaIcon.gameObject.SetActive(false);
        }
        else if (itemEquipada is PoteDeVida)
        {
            espadaIcon.gameObject.SetActive(false);
            curaIcon.gameObject.SetActive(true);
        }
    }    
    public void UseItem()
    {
        if (itemEquipada != null)
        {
            itemEquipada.Use();  
        }
    }
}
