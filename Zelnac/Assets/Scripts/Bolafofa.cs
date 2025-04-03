using System.Collections;
using UnityEngine;

public class Bolafofa : MonoBehaviour
{
    public GameObject bolaDeFogoPrefab; // Prefab da bola de fogo
    public Transform firePoint; // Ponto de spawn da bola
    public float cooldown = 1f;
    private bool podeAtacar = true;

    void Update()
    {
        if (podeAtacar && (Input.GetButtonDown("Fire1") || Input.GetMouseButtonDown(0)))
        {
            StartCoroutine(Cooldown());
            AtirarBolaDeFogo();
        }
    }

    void AtirarBolaDeFogo()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f; // Garante que a bola fique no mesmo plano do jogo

        GameObject bola = Instantiate(bolaDeFogoPrefab, firePoint.position, Quaternion.identity);
        bola.GetComponent<BolaDeFogo>().SetDirection(mousePos);
    }

    IEnumerator Cooldown()
    {
        podeAtacar = false;
        yield return new WaitForSeconds(cooldown);
        podeAtacar = true;
    }
}
