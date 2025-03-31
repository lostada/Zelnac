using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolafofa : MonoBehaviour
{
    public GameObject fogo;
    public int danao = 30;
    public float cooldown = 2f;
    bool atacoCuldown;
    bool atacaPar�a;
    Enemy enemy;
    Transform lugarintancia;
    [SerializeField] float faritoBalVelocidade;
    // Start is called before the first frame update
    void Start()
    {
        enemy = FindObjectOfType<Enemy>();
        atacoCuldown = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            atacaPar�a = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            atacaPar�a = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        atacaPar�a = true;
        atacoCuldown = true;
        if (atacaPar�a && atacoCuldown && Input.GetButtonDown("Fire1"))
        {
         
            GameObject obj = Instantiate(fogo);
            obj.GetComponent<Rigidbody2D>().velocity = new Vector3(0,1,0).normalized *faritoBalVelocidade;
            Attack();
        }
    }

    void Attack()
    {
        print("oi");
        enemy.TakeDamage(10);
        StartCoroutine(Coolwon());
    }

    IEnumerator Coolwon()
    {
        atacoCuldown = true;
        yield return new WaitForSeconds(cooldown);
        atacoCuldown = !atacoCuldown;
    }
}
