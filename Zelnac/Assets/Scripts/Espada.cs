using System.Collections;
using UnityEngine;

public class Espada : Item
{
    public int dano = 10;
    public GameObject spritedamage;
    bool podeAtaca;
    public Transform lugarQueInstancia;
    void Start()
    {
        itemName = "Espada";
        
    }

    public override void Use()
    {
        Debug.Log("Espada usada!");
    }

    public override void Equip()
    {
        Debug.Log("Espada equipada!");
    }
    private void Update()
    {
        if(podeAtaca && Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }
    void Attack()
    {
        StartCoroutine(NumeroSobe());
        Enemy enemy = FindObjectOfType<Enemy>();
        if (enemy != null)
        {
            enemy.ReceberDano(dano);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            podeAtaca = true;

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            podeAtaca = false;
        }
    }
    IEnumerator NumeroSobe()
    {
        print("s");
        GameObject oqSobe = Instantiate(spritedamage, lugarQueInstancia.position, transform.rotation);
        yield return new WaitForSeconds(0.3f);
        Destroy(oqSobe);
    }
}
