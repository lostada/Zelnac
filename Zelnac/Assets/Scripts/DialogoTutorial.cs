using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogoTutorial : MonoBehaviour
{
    [System.Serializable]
    public class Dialogo
    {
        public string texto;  // Texto do diálogo
        public Sprite imagem; // Imagem associada
    }

    public TextMeshProUGUI dialogoTexto;
    public Image dialogoImagem;
    public List<Dialogo> dialogos; // Lista de diálogos

    private int indiceAtual = 0;
    public float tempoTroca = 3f; // Tempo entre cada troca

    void Start()
    {
        AtualizarDialogo();
        StartCoroutine(TrocarDialogoAutomaticamente());
    }

    void AtualizarDialogo()
    {
        if (indiceAtual < dialogos.Count)
        {
            dialogoTexto.text = dialogos[indiceAtual].texto;
            dialogoImagem.sprite = dialogos[indiceAtual].imagem;
        }
        else
        {
            gameObject.SetActive(false); // Esconde o tutorial quando acabar
        }
    }

    IEnumerator TrocarDialogoAutomaticamente()
    {
        while (indiceAtual < dialogos.Count)
        {
            yield return new WaitForSeconds(tempoTroca);
            indiceAtual++;
            AtualizarDialogo();
        }
    }
}
