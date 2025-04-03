using UnityEngine;

public class Projeteis : MonoBehaviour
{
    public float speed = 5f;
    private Transform player;
    private Vector2 targetDirection;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player != null)
        {
            targetDirection = (player.position - transform.position).normalized;
        }
        Destroy(gameObject, 5f); // Destroi após 5s para evitar lixo na cena
    }

    void Update()
    {
        transform.position += (Vector3)targetDirection * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStatus>()?.TakeDmg(10); // Causa dano ao player
            Destroy(gameObject);
        }
    }
}
