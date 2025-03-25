using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PoteDeVida : Item
{
    public int cura = 20;
    ItemDisplay oi;
    ItemDisplay player;
    public GameObject espada;
    void Start()
    {
        player = FindObjectOfType<ItemDisplay>();  
        itemName = "Pote de Vida";
        oi = FindObjectOfType<ItemDisplay>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            Use();
        }
    }
    public override void Use()
    {
        Debug.Log("Pote de Vida usado!");
        FindObjectOfType<Player>().RestaurarVida(cura);
        Destroy(oi.curaGameObject);
        Destroy(oi.curaIcon);
        player.espadaGameObject.SetActive(true);
    }

    public override void Equip()
    {
        Debug.Log("Pote de Vida equipado!");
    }
}
