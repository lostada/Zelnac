using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public Image espadaIcon;
    public Image curaIcon;
    public GameObject espadaGameObject;
    public GameObject curaGameObject;

    private Item itemEquipada;
    private bool isSwordEquipped = false;

    void Start()
    {
        espadaIcon.gameObject.SetActive(false);
        curaIcon.gameObject.SetActive(false);
        espadaGameObject.SetActive(false);
        curaGameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwapItems();
        }
    }

    public void UpdateItemDisplay(Item item)
    {
        itemEquipada = item;

        if (itemEquipada is Espada)
        {
            espadaIcon.gameObject.SetActive(true);
            curaIcon.gameObject.SetActive(false);
            espadaGameObject.SetActive(true);
            curaGameObject.SetActive(false);
            isSwordEquipped = true;
        }
        else if (itemEquipada is PoteDeVida)
        {
            espadaIcon.gameObject.SetActive(false);
            curaIcon.gameObject.SetActive(true);
            espadaGameObject.SetActive(false);
            curaGameObject.SetActive(true);
            isSwordEquipped = false;
        }
    }

    public void SwapItems()
    {
        if (isSwordEquipped)
        {
            espadaGameObject.SetActive(false);
            curaGameObject.SetActive(true);
            espadaIcon.gameObject.SetActive(false);
            curaIcon.gameObject.SetActive(true);
            isSwordEquipped = false;
        }
        else
        {
            curaGameObject.SetActive(false);
            espadaGameObject.SetActive(true);
            curaIcon.gameObject.SetActive(false);
            espadaIcon.gameObject.SetActive(true);
            isSwordEquipped = true;
        }
    }
}
