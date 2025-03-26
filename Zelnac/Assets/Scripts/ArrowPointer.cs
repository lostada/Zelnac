using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPointer : MonoBehaviour
{
    public Transform target; // O alvo para o qual a seta deve apontar
    public RectTransform arrowUI; // A seta na interface do usuário (UI)

    void Update()
    {
        // Verifica se o target foi atribuído
        if (target != null)
        {
            // Converte a posição do alvo para o espaço da tela (em pixels)
            Vector3 screenPos = Camera.main.WorldToScreenPoint(target.position);

            // Calcula a direção do alvo em relação à tela
            Vector3 direction = screenPos - arrowUI.position;

            // Calcula o ângulo entre a direção e o eixo X
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Aplica a rotação na seta UI para que ela aponte para o alvo
            arrowUI.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}
