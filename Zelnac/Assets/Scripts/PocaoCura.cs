using UnityEngine;

public class PocaoCura : MonoBehaviour
{
    public int cura = 1; // Vida que a poção cura
    public GameObject potionObject; // Poção que será destruída

    private bool usada = false; // Evita o uso múltiplo

    private void Update()
    {
        if (!usada && Input.GetKeyDown(KeyCode.H)) // Se apertar "H" e a poção ainda não foi usada
        {
            PlayerStatus player = FindObjectOfType<PlayerStatus>(); // Acha o player na cena
            
            if (player != null)
            {
                player.Curar(cura);
                usada = true; // Marca como usada
                Debug.Log("Poção usada!");

                if (potionObject != null) 
                {
                    Destroy(potionObject); // Destrói o objeto da poção
                }
                else
                {
                    Debug.LogError("PotionObject não foi atribuído no Inspector!");
                }
            }
            else
            {
                Debug.LogError("PlayerStatus não encontrado!");
            }
        }
    }
}
