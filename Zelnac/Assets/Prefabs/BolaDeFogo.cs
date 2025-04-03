using UnityEngine;

public class BolaDeFogo : MonoBehaviour
{
    public float speed = 10f; // Velocidade da bola de fogo
    public int damage = 1; // Dano que a bola de fogo causa
    public float lifetime = 3f; // Tempo antes de destruir a bola

    private Vector3 direction; 

    void Start()
    {
        Destroy(gameObject, lifetime); // Destroi após um tempo
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    public void SetDirection(Vector3 target)
    {
        direction = (target - transform.position).normalized; // Define a direção em direção ao mouse
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<InimigoVida>()?.ReceberDano(damage);
            Destroy(gameObject); // Destroi a bola ao acertar o inimigo
        }
    }
}
