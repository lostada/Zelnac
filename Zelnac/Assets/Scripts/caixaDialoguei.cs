using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caixaDialoguei : MonoBehaviour
{
    public GameObject dialogo;
    public GameObject porta;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("caixa"))
        {
            Destroy(porta);
            print("manuzita");
            dialogo.SetActive(true);                  
        }
    }
}
