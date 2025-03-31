using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sword : MonoBehaviour
{

    public int danado = 10;
    public float cudown = 0.7f;
    bool podeAtacColdon;
    bool podeAtac;
    Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = FindObjectOfType<Enemy>();
        podeAtacColdon = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            podeAtac = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            podeAtac = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (podeAtac && podeAtacColdon && Input.GetButtonDown("Fire1"))
        {
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
        podeAtacColdon = true;
        yield return new WaitForSeconds(cudown);
        podeAtacColdon = !podeAtacColdon;
    }
}
