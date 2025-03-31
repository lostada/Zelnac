using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMov : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector3 escalaOriginal;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        escalaOriginal = transform.localScale;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        if (movement.x < 0)
            transform.localScale = new Vector3(-escalaOriginal.x, escalaOriginal.y, escalaOriginal.z); 
        else if (movement.x > 0)
            transform.localScale = escalaOriginal; 
    }

    void FixedUpdate()
    {
        rb.velocity = movement * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Porta"))
        {
            SceneManager.LoadScene("Nivel1");
        }
    }
}
