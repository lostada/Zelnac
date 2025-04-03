using System.Collections;
using UnityEngine;

public class ButtonActivator : MonoBehaviour
{
    public GameObject[] buttons; // Array de bot�es
    private int currentIndex = 0;

    void Start()
    {
        StartCoroutine(ActivateButtons());
    }

    IEnumerator ActivateButtons()
    {
        while (true) // Loop infinito
        {
            // Desativa todos os bot�es
            foreach (GameObject btn in buttons)
            {
                btn.SetActive(false);
            }

            // Ativa o bot�o atual
            buttons[currentIndex].SetActive(true);

            // Espera 5 segundos antes de ativar o pr�ximo bot�o
            yield return new WaitForSeconds(5f);

            // Passa para o pr�ximo bot�o (circular)
            currentIndex = (currentIndex + 1) % buttons.Length;
        }
    }
}
