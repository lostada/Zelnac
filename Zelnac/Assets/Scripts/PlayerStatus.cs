using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int life;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (life < 0)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDmg(int dmg)
    {
        life -= dmg;
        StartCoroutine(MusdaCOr());
    }
    IEnumerator MusdaCOr()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.25f);
        sprite.color = Color.white;
    }
}
