using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class InimigoPersegue : MonoBehaviour
{
    public float velocidade = 2f; 
    private Transform alvo; 
    private Rigidbody2D rb;
    public GameObject inimigao;
    public GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        alvo = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    void Update()
    {
        if (alvo != null)
        {
            Vector2 direcao = (alvo.position - transform.position).normalized; 
            rb.velocity = direcao * velocidade; 
        }
    }
    }
