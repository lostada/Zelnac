using UnityEngine;

public class Dummy : Enemy
{
    public override void Morrer()
    {
        Debug.Log("Voc� matou o seu unico amigo aqui.");
        Destroy(gameObject);
    }
}
