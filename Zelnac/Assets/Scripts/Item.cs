using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public abstract class Item : MonoBehaviour
{
    public string itemName;

    public abstract void Use();  // O método Use sem parâmetros
    public abstract void Equip();  // Adiciona o método Equip() na classe Item
}
