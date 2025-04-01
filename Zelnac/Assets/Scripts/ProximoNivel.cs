using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProximoNivel : MonoBehaviour
{
    public GameObject estatua;
    bool apertou;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(apertou && Input.GetKeyDown(KeyCode.R)) 
        {
            SceneManager.LoadScene("venturaLg");
            Debug.Log("tchau");
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
          
            apertou = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            apertou = false;
    }
}
