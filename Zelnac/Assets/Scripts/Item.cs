using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public abstract class Item : MonoBehaviour
{
    public string itemName;

    public abstract void Use();
}
