using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerStatus : MonoBehaviour
{
    public int life = 3; // Vida inicial
    public int maxLife = 3; // Vida máxima
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        if (sprite == null)
        {
            Debug.LogError("SpriteRenderer não encontrado no Player!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) 
{
    Debug.Log("Tentando curar...");
    Curar(1);
}


        if (life <= 0) 
        {
            RestartScene(); 
        }
    }

    public void TakeDmg(int dmg)
    {
        life -= dmg;
        if (life < 0) life = 0;
        StartCoroutine(MusdaCOr());
    }

    public void Curar(int quantidade)
    {
        if (life < maxLife) // Só cura se não estiver no máximo
        {
            life += quantidade;
            if (life > maxLife) life = maxLife; // Garante que não ultrapasse o limite
            Debug.Log("Coração restaurado! Vida atual: " + life);
        }
        else
        {
            Debug.Log("Vida já está cheia!");
        }
    }

    IEnumerator MusdaCOr()
    {
        if (sprite != null)
        {
            sprite.color = Color.red;
            yield return new WaitForSeconds(0.25f);
            sprite.color = Color.white;
        }
    }

    void RestartScene()
    {
        Debug.Log("Reiniciando cena...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
