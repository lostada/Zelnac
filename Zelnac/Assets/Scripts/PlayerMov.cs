using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMov : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float dashSpeed = 15f; 
    public float dashDuration = 0.2f; 
    public float dashCooldown = 1f; 

    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector3 escalaOriginal;
    private bool isDashing = false;
    private bool canDash = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        escalaOriginal = transform.localScale;
    }

    void Update()
    {
        if (!isDashing) 
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            movement.Normalize();

            if (movement.x < 0)
                transform.localScale = new Vector3(-escalaOriginal.x, escalaOriginal.y, escalaOriginal.z); 
            else if (movement.x > 0)
                transform.localScale = escalaOriginal; 

            if (Input.GetKeyDown(KeyCode.Q) && canDash && movement != Vector2.zero)
            {
                StartCoroutine(Dash());
            }
        }
    }

    void FixedUpdate()
    {
        if (!isDashing)
        {
            rb.velocity = movement * moveSpeed;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;

        rb.velocity = movement * dashSpeed;

        yield return new WaitForSeconds(dashDuration);

        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Porta"))
        {
            SceneManager.LoadScene("Nivel1");
        }
    }
}
