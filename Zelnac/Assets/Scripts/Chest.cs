using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Chest : MonoBehaviour
{
    public GameObject sword;
    public GameObject lifePotion;
    public GameObject interactionImage;
    public TextMeshProUGUI dicaTexto;  // Arraste o objeto de texto da UI aqui

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

        if (dicaTexto != null)
        {
            dicaTexto.gameObject.SetActive(false); // Esconde a dica de texto no início
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

        // Exibir dica de texto
        if (dicaTexto != null)
        {
            dicaTexto.text = "Aperte Q para alternar os items e Aperte E para usar-los";

            dicaTexto.gameObject.SetActive(true);
            Invoke("EsconderDica", 3f); // Esconder dica após 3 segundos
        }

        gameObject.SetActive(false);
    }

    void EsconderDica()
    {
        if (dicaTexto != null)
        {
            dicaTexto.gameObject.SetActive(false);
        }
    }
}
