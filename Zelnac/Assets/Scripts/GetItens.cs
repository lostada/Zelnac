using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItens : MonoBehaviour
{
    public GameObject itemType;
    public GameObject itemTypeIMG;
    public GameObject bauGameObjeto;
    public GameObject bauAberto;
    public GameObject bauFechado;
    bool podePegar;
    Itens itens;
    // Start is called before the first frame update
    void Start()
    {
        itens = FindObjectOfType<Itens>();
    }

    // Update is called once per frame
    void Update()
    {
        if (podePegar && Input.GetKeyDown(KeyCode.E))
        {
            bauFechado.SetActive(false);
            bauAberto.SetActive(true);
            GetItem();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            podePegar = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            podePegar = false;
        }
    }
    void GetItem()
    {
        itens.itemsObj.Add(itemType);
        itens.itemsImg.Add(itemTypeIMG);
        Destroy(bauGameObjeto);
    }
}
