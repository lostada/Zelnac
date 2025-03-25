using System.Collections;
using UnityEngine;
using TMPro;

public class TriggerMensagem : MonoBehaviour
{
    public GameObject mensagemUI;
    public TextMeshProUGUI textoUI;
    public Transform player;
    public Canvas canvas;
    public float tempoExibicao = 2f;
    public float fadeSpeed = 1.5f;

    private CanvasGroup canvasGroup;
    private RectTransform uiTransform;
    private bool isFollowing = false;
    private Camera mainCamera;

    void Start()
    {
        if (mensagemUI != null)
        {
            uiTransform = mensagemUI.GetComponent<RectTransform>();
            canvasGroup = mensagemUI.GetComponent<CanvasGroup>();

            if (canvasGroup == null)
                canvasGroup = mensagemUI.AddComponent<CanvasGroup>();

            mensagemUI.SetActive(false);
            canvasGroup.alpha = 0f;
        }

        mainCamera = Camera.main;
    }

    void Update()
    {
        if (isFollowing && player != null)
        {
            Vector3 screenPos = mainCamera.WorldToViewportPoint(player.position);
            Vector2 uiPos = new Vector2(
                (screenPos.x * canvas.GetComponent<RectTransform>().sizeDelta.x) - (canvas.GetComponent<RectTransform>().sizeDelta.x / 2),
                (screenPos.y * canvas.GetComponent<RectTransform>().sizeDelta.y) - (canvas.GetComponent<RectTransform>().sizeDelta.y / 2)
            );

            uiTransform.anchoredPosition = uiPos;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            mensagemUI.SetActive(true);
            isFollowing = true;
            StartCoroutine(ExibirMensagem());
        }
    }

    IEnumerator ExibirMensagem()
    {
        float elapsedTime = 0f;

        while (elapsedTime < 1f / fadeSpeed)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsedTime * fadeSpeed);
            yield return null;
        }

        yield return new WaitForSeconds(tempoExibicao);

        elapsedTime = 0f;
        while (elapsedTime < 1f / fadeSpeed)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, elapsedTime * fadeSpeed);
            yield return null;
        }

        mensagemUI.SetActive(false);
        isFollowing = false;
    }
}
