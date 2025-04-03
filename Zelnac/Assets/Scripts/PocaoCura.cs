using UnityEngine;

public class PocaoCura : MonoBehaviour
{
    public int cura = 1; // Vida que a po��o cura
    public GameObject potionObject; // Po��o que ser� destru�da

    private bool usada = false; // Evita o uso m�ltiplo

    private void Update()
    {
        if (!usada && Input.GetKeyDown(KeyCode.H)) // Se apertar "H" e a po��o ainda n�o foi usada
        {
            PlayerStatus player = FindObjectOfType<PlayerStatus>(); // Acha o player na cena
            
            if (player != null)
            {
                player.Curar(cura);
                usada = true; // Marca como usada
                Debug.Log("Po��o usada!");

                if (potionObject != null) 
                {
                    Destroy(potionObject); // Destr�i o objeto da po��o
                }
                else
                {
                    Debug.LogError("PotionObject n�o foi atribu�do no Inspector!");
                }
            }
            else
            {
                Debug.LogError("PlayerStatus n�o encontrado!");
            }
        }
    }
}
