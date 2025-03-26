using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPointer : MonoBehaviour
{
    public Transform target; // O alvo para o qual a seta deve apontar
    public RectTransform arrowUI; // A seta na interface do usu�rio (UI)

    void Update()
    {
        // Verifica se o target foi atribu�do
        if (target != null)
        {
            // Converte a posi��o do alvo para o espa�o da tela (em pixels)
            Vector3 screenPos = Camera.main.WorldToScreenPoint(target.position);

            // Calcula a dire��o do alvo em rela��o � tela
            Vector3 direction = screenPos - arrowUI.position;

            // Calcula o �ngulo entre a dire��o e o eixo X
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Aplica a rota��o na seta UI para que ela aponte para o alvo
            arrowUI.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}
