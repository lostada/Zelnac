using System.Collections;
using UnityEngine;

public class ButtonActivator : MonoBehaviour
{
    public GameObject[] buttons; // Array de botões
    private int currentIndex = 0;

    void Start()
    {
        StartCoroutine(ActivateButtons());
    }

    IEnumerator ActivateButtons()
    {
        while (true) // Loop infinito
        {
            // Desativa todos os botões
            foreach (GameObject btn in buttons)
            {
                btn.SetActive(false);
            }

            // Ativa o botão atual
            buttons[currentIndex].SetActive(true);

            // Espera 5 segundos antes de ativar o próximo botão
            yield return new WaitForSeconds(5f);

            // Passa para o próximo botão (circular)
            currentIndex = (currentIndex + 1) % buttons.Length;
        }
    }
}
