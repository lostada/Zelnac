using UnityEngine;

public class Seta: MonoBehaviour
{
    public Transform alvo; // O objeto que a seta deve apontar

    void Update()
    {
        if (alvo != null)
        {
            // Calcula a direção até o alvo
            Vector3 direcao = alvo.position - transform.position;
            float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;

            // Rotaciona a seta para apontar para o alvo
            transform.rotation = Quaternion.Euler(0, 0, angulo);
        }
        else
        {
            // Se o alvo for destruído, desativa a seta
            gameObject.SetActive(false);
        }
    }
}
