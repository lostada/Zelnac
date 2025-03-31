using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BolaFofoDMG : MonoBehaviour
{
    InimigoVida enemy;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        enemy = FindObjectOfType<InimigoVida>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemy.ReceberDano(damage);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
