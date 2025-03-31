using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMov : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public GameObject player;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

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
