using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocaoCura : MonoBehaviour
{
    public int cura = 1; // A poção recupera 1 coração

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerStatus player = other.GetComponent<PlayerStatus>();

        if (player != null)
        {
            //player.Curar(cura);//
            Destroy(gameObject);
        }
    }
}
