using UnityEngine;

public class Dummy : Enemy
{
    public override void Morrer()
    {
        // A l�gica de morte do Dummy pode ser diferente da l�gica de morte do inimigo padr�o
        Debug.Log("Dummy morreu de uma forma especial!");
        Destroy(gameObject);  // Destroi o objeto Dummy
    }
}
