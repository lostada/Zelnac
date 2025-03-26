using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : Itens
{

    int listIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TrocarItems();
        }
    }
    void TrocarItems()
    {
        
        if (itemsObj.Count > 0 && itemsObj[listIndex] != null)
        {
            itemsObj[listIndex].SetActive(false);
            itemsImg[listIndex].SetActive(false);
        }

        listIndex = (listIndex + 1) % itemsObj.Count;

        if (itemsObj.Count > 0 && itemsObj[listIndex] != null)
        {
            itemsObj[listIndex].SetActive(true);
            itemsImg[listIndex].SetActive(true);
        }
    }
    
}

