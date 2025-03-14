using UnityEngine;
using Unity.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public GameObject sword; 
    public GameObject interactionImage; 
    private bool playerNearby = false;

    void Start()
    {
        if (interactionImage != null)
        {
            interactionImage.SetActive(false); 
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            if (interactionImage != null)
            {
                interactionImage.SetActive(true); 
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            if (interactionImage != null)
            {
                interactionImage.SetActive(false); 
            }
        }
    }

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            EquipSword();
        }
    }

    void EquipSword()
    {
        if (sword != null)
        {
            sword.SetActive(true); 
        }

        if (interactionImage != null)
        {
            interactionImage.SetActive(false); 
        }

        gameObject.SetActive(false);
    }
}
