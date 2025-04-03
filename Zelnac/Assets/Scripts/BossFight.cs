using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossFight : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject spikePrefab;
    public Transform attackPoint;
    public float slashRange = 2f;
    public int slashDamage = 20;
    public LayerMask playerLayer;
    private Transform player;

    public Slider healthSlider;
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
            Debug.Log("Player encontrado: " + player.name);
        }
        else
        {
            Debug.LogError("Player não encontrado! Verifique a tag 'Player'.");
        }

        currentHealth = maxHealth;
        UpdateHealthUI();
        StartCoroutine(StartAttackDelay());
    }

    IEnumerator StartAttackDelay()
    {
        yield return new WaitForSeconds(5f);
        if (player != null)
        {
            StartCoroutine(SpawnSpikesContinuously());
            StartCoroutine(BossAttackPattern());
        }
    }

    IEnumerator SpawnSpikesContinuously()
    {
        while (player != null)
        {
            GameObject spike = Instantiate(spikePrefab, player.position, Quaternion.identity);
            Destroy(spike, 2f);
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator BossAttackPattern()
    {
        while (player != null)
        {
            for (int i = 0; i < 10; i++)
            {
                Instantiate(projectilePrefab, attackPoint.position, Quaternion.identity);
                yield return new WaitForSeconds(0.2f);
            }

            SlashAttack();
            yield return new WaitForSeconds(1f);
        }
    }

    void SlashAttack()
    {
        Collider2D hitPlayer = Physics2D.OverlapCircle(transform.position, slashRange, playerLayer);
        if (hitPlayer != null)
        {
            Debug.Log("Player atingido pelo ataque de foice!");
            hitPlayer.GetComponent<PlayerStatus>()?.TakeDmg(slashDamage);
        }
        else
        {
            Debug.Log("Ataque de foice falhou! Nenhum jogador detectado.");
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.value = (float)currentHealth / maxHealth;
        }
    }

    void Die()
    {
        Debug.Log("Boss derrotado!");
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, slashRange);
    }
}
