using UnityEngine;

public class Espada : Item
{
    public int dano = 10; // Dano da espada

    void Start()
    {
        itemName = "Espada";
    }

    public override void Use()
    {
        // Pode adicionar algum efeito visual, anima��o ou som para a espada
        Debug.Log("Espada usada!");
    }

    // Implementa��o do m�todo Equip()
    public override void Equip()
    {
        // Aqui voc� pode adicionar o comportamento quando a espada � equipada
        Debug.Log("Espada equipada!");
    }

    // Detecta colis�es com inimigos ao entrar no trigger da espada
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto com o qual a espada colidiu tem a tag "Enemy"
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.ReceberDano(dano);  // Aplica o dano ao inimigo
            }
        }
    }
}
