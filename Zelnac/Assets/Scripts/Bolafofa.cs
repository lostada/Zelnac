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
        if (atacoCooldown && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)))
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

        // Verifica qual tecla foi pressionada
        if (Input.GetKeyDown(KeyCode.D)) // Se pressionar D, vai para a direita
        {
            rb.velocity = new Vector2(velocidadeBola, 0);
        }
        else if (Input.GetKeyDown(KeyCode.A)) // Se pressionar A, vai para a esquerda
        {
            rb.velocity = new Vector2(-velocidadeBola, 0);
        }
    }

    IEnumerator Cooldown()
    {
        atacoCooldown = false;
        yield return new WaitForSeconds(cooldown);
        atacoCooldown = true;
    }
}
