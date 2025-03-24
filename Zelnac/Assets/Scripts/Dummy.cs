using UnityEngine;

public class Dummy : Enemy
{
    public override void Morrer()
    {
        Debug.Log("Você matou o seu unico amigo aqui.");
        Destroy(gameObject);
    }
}
