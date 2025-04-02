using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoApareceBau : MonoBehaviour
{
    public GameObject dialogo;
    bool podeApertar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && podeApertar)
        {
            dialogo.SetActive(true);
            Destroy(gameObject);
            
        }
      
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            podeApertar = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            podeApertar = false;
        }
    }
 }
