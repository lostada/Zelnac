using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolafofa : MonoBehaviour
{
    public GameObject fogo; // Prefab da bola de fogo
    public float cooldown = 1f;
    private bool atacoCooldown;
    [SerializeField] private float velocidadeBola;

    void Start()
    {
        atacoCooldown = true;
    }

    void Update()
    {
        // Verifica se o player pressionou o mouse ou o "Fire1" (que por padrão é o botão esquerdo do mouse)
        if (atacoCooldown && (Input.GetButtonDown("Fire1") || Input.GetMouseButtonDown(0)))
        {
            StartCoroutine(Cooldown());
            AtirarBolaDeFogo();
        }
    }

    void AtirarBolaDeFogo()
    {
        // Instancia a bola de fogo na posição do player
        GameObject obj = Instantiate(fogo, transform.position, Quaternion.identity);
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();

        // Verifica se o player está pressionando "D" ou "A"
        if (Input.GetKey(KeyCode.D)) // Se pressionar D, vai para a direita
        {
            rb.velocity = new Vector2(velocidadeBola, 0);
        }
        else if (Input.GetKey(KeyCode.A)) // Se pressionar A, vai para a esquerda
        {
            rb.velocity = new Vector2(-velocidadeBola, 0);
        }
        else
        {
            // Caso nenhum botão seja pressionado, a bola não se move
            rb.velocity = Vector2.zero;
        }
    }

    IEnumerator Cooldown()
    {
        atacoCooldown = false;
        yield return new WaitForSeconds(cooldown);
        atacoCooldown = true;
    }
}
