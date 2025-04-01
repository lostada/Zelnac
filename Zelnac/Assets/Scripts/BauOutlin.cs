using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BauOutlin : MonoBehaviour
{
    public GameObject baulinha;
    void Start()
    {
        baulinha.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            baulinha.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            baulinha.SetActive(false);
    }
}
