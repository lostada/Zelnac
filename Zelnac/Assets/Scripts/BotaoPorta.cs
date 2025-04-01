using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoPorta : MonoBehaviour
{
    public GameObject port;
    public GameObject port2;
    bool abriu;
    public Animator animator;
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
        if(collision.CompareTag("Player"))
        {
            port.SetActive(false);
            port2.SetActive(true);
            animator.SetTrigger("naoimporta");
            abriu = true;
        }
    }
}
