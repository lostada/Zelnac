using UnityEngine;

public class Dummy : Enemy
{
    public GameObject pota;
    public override void Morrer()
    {
        Debug.Log("Você matou o seu unico amigo aqui.");
        pota.SetActive(true);
        Destroy(gameObject);
    }
}
