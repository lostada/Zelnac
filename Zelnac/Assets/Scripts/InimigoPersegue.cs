using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPersegue : MonoBehaviour
{
    public float velocidade = 2f;
    public float alcancePerseguicao = 5f; // Distância máxima para perseguir o player
    private Transform alvo;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        alvo = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (alvo != null)
        {
            float distancia = Vector2.Distance(transform.position, alvo.position); // Calcula a distância até o player

            if (distancia <= alcancePerseguicao) // Se o player estiver no alcance
            {
                Vector2 direcao = (alvo.position - transform.position).normalized;
                rb.velocity = direcao * velocidade;
            }
            else
            {
                rb.velocity = Vector2.zero; // Para o inimigo se o player sair do alcance
            }
        }
    }
}
