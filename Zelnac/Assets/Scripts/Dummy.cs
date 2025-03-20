using UnityEngine;

public class Dummy : Enemy
{
    public override void Morrer()
    {
        Debug.Log("Dummy morreu de uma forma especial!");
        Destroy(gameObject);
    }
}
