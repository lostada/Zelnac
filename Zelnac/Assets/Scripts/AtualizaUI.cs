using UnityEngine;
using UnityEngine.UI;

public class AtualizaUI : MonoBehaviour
{
    public Image[] hearts;
    private PlayerStatus status;

    void Start()
    {
        status = FindObjectOfType<PlayerStatus>();
        if (status == null)
        {
            Debug.LogError("PlayerStatus não encontrado!");
        }
    }

    void Update()
    {
        HeartsVerify();
    }

    void HeartsVerify()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].color = i < status.life ? Color.red : Color.grey;
        }
    }
}
