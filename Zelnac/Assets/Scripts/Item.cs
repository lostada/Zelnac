using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public abstract class Item : MonoBehaviour
{
    public string itemName;

    public abstract void Use();  // O m�todo Use sem par�metros
    public abstract void Equip();  // Adiciona o m�todo Equip() na classe Item
}
