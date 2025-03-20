using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public GameObject sword;
    public GameObject lifePotion; // Pote de Vida
    public GameObject interactionImage;
    private bool playerNearby = false;
    private bool itemEquipped = false;

    void Start()
    {
        if (interactionImage != null)
        {
            interactionImage.SetActive(false); // Inicializa a imagem de interação
        }

        if (sword != null)
        {
            sword.SetActive(false); // A espada começa desativada
        }

        if (lifePotion != null)
        {
            lifePotion.SetActive(false); // O Pote de Vida também começa desativado
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            if (interactionImage != null)
            {
                interactionImage.SetActive(true); // Exibe a imagem de interação quando o player se aproxima
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
                interactionImage.SetActive(false); // Oculta a imagem de interação quando o player sai
            }
        }
    }

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            EquipItem(); // Quando pressionado E, o item é equipado
        }
    }

    void EquipItem()
    {
        if (!itemEquipped)
        {
            // Ativa a espada ou o pote de vida com base no item associado ao baú
            if (sword != null)
            {
                sword.SetActive(true);  // Ativa a espada
            }

            if (lifePotion != null)
            {
                lifePotion.SetActive(true); // Ativa o pote de vida
            }

            itemEquipped = true; // Marca que o item foi equipado
        }

        if (interactionImage != null)
        {
            interactionImage.SetActive(false); // Remove a imagem de interação após pegar o item
        }

        gameObject.SetActive(false); // Desativa o baú
    }
}
