using System.Collections;
using UnityEngine;

public class InimigoVida : MonoBehaviour
{
    public GameObject dialogo;
    public GameObject enemy;
    public GameObject porta;
    public GameObject porta1;
    public int vida = 90;
    public GameObject seta;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Pega o sprite do inimigo
    }

    public void ReceberDano(int dano)
    {
        vida -= dano;
        Debug.Log("ele ta com " + vida);

        StartCoroutine(TomarDanoVisual()); // Ativa o efeito de dano

        if (vida <= 0)
        {
            Morrer();
        }
    }

    IEnumerator TomarDanoVisual()
    {
        spriteRenderer.color = Color.red; // Fica vermelho
        yield return new WaitForSeconds(0.25f); // Espera 0.25s
        spriteRenderer.color = Color.white; // Volta ao normal
    }

    void Morrer()
    {
        Debug.Log("Inimigo derrotado!");
        enemy.SetActive(false);
        dialogo.SetActive(true);
        porta.SetActive(true);
        porta1.SetActive(true);
        seta.SetActive(true);   
    }
}
