using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    public ItemDisplay itemDisplay;

    private Item itemEquipada;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        EquiparItem(new Espada()); 
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        if (Input.GetKeyDown(KeyCode.E))
        {
            itemEquipada.Use();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            TrocarItem();
        }
    }
    void FixedUpdate()
    {
        rb.velocity = movement * moveSpeed;
    }

    void EquiparItem(Item novoItem)
    {
        itemEquipada = novoItem;
        itemDisplay.UpdateItemDisplay(itemEquipada);
    }

    void TrocarItem()
    {
        if (itemEquipada is Espada)
        {
            EquiparItem(new PoteDeVida());
        }
        else
        {
            EquiparItem(new Espada());
        }
    }
}
