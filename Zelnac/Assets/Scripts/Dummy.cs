using UnityEngine;

public class Dummy : Enemy
{
    public override void Morrer()
    {
        // A lógica de morte do Dummy pode ser diferente da lógica de morte do inimigo padrão
        Debug.Log("Dummy morreu de uma forma especial!");
        Destroy(gameObject);  // Destroi o objeto Dummy
    }
}
