using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Importa UI para usar Image

public class BossFight : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab do projétil
    public GameObject spikePrefab; // Prefab dos espinhos
    public Transform attackPoint; // Ponto de spawn dos projéteis
    public int projectileCount = 10;
    public float slashRange = 2f;
    public int slashDamage = 20;
    public LayerMask playerLayer; // Camada do player
    private Transform player;

    public GameObject[] buttons; // Lista de botões
    public Image[] bossLifeImages; // Referência aos corações na UI
    public Sprite[] bossLifeSprites; // Sprites de vida do boss
    private int bossLife = 6;
    private int currentButtonIndex = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(StartAttackDelay());
        StartCoroutine(ActivateButtons());
    }

    IEnumerator StartAttackDelay()
    {
        yield return new WaitForSeconds(5f); // Delay de 5s antes do boss começar a atacar
        StartCoroutine(SpawnSpikesContinuously());
        StartCoroutine(BossAttackPattern());
    }

    IEnumerator BossAttackPattern()
    {
        while (true)
        {
            // Fase 1: Disparar projéteis
            for (int i = 0; i < projectileCount; i++)
            {
                Instantiate(projectilePrefab, attackPoint.position, Quaternion.identity);
                yield return new WaitForSeconds(0.2f); // Pequeno delay entre os tiros
            }

            // Fase 2: Ataque de foice
            SlashAttack();
        }
    }

    void SlashAttack()
    {
        Collider2D hitPlayer = Physics2D.OverlapCircle(transform.position + transform.right * slashRange, 1f, playerLayer);
        if (hitPlayer != null)
        {
            hitPlayer.GetComponent<PlayerStatus>()?.TakeDmg(slashDamage);
        }
    }

    IEnumerator SpawnSpikesContinuously()
    {
        while (true)
        {
            if (player != null)
            {
                GameObject spike = Instantiate(spikePrefab, player.position, Quaternion.identity);
                Destroy(spike, 2f); // Espinho desaparece após 2s
            }
            yield return new WaitForSeconds(1f); // Espinhos surgem a cada 1s na posição do player
        }
    }

    IEnumerator ActivateButtons()
    {
        while (currentButtonIndex < buttons.Length)
        {
            buttons[currentButtonIndex].SetActive(true);
            yield return new WaitForSeconds(5f);
            currentButtonIndex++;
        }
    }

    public void ButtonPressed()
    {
        if (bossLife > 0)
        {
            bossLife--;
            UpdateBossUI();
        }
    }

    void UpdateBossUI()
    {
        if (bossLife >= 0 && bossLife < bossLifeSprites.Length)
        {
            bossLifeImages[bossLife].sprite = bossLifeSprites[bossLife];
        }
    }

    void OnDrawGizmos()
    {
        // Gizmo para visualizar o alcance do corte
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + transform.right * slashRange, 1f);
    }
}
