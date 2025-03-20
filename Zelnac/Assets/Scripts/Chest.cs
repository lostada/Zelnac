using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public GameObject sword;
    public GameObject lifePotion; 
    public GameObject interactionImage;
    private bool playerNearby = false;
    private bool itemEquipped = false;

    void Start()
    {
        if (interactionImage != null)
        {
            interactionImage.SetActive(false);
        }

        if (sword != null)
        {
            sword.SetActive(false); 
        }

        if (lifePotion != null)
        {
            lifePotion.SetActive(false); 
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
            EquipItem();
        }
    }

    void EquipItem()
    {
        if (!itemEquipped)
        {
            if (sword != null)
            {
                sword.SetActive(true);  
            }

            if (lifePotion != null)
            {
                lifePotion.SetActive(true); 
            }

            itemEquipped = true;
        }

        if (interactionImage != null)
        {
            interactionImage.SetActive(false);
        }

        gameObject.SetActive(false);
    }
}
