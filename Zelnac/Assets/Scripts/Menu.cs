using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PassarDeFase()
    {
        SceneManager.LoadSceneAsync(1); 
    }
    public void Saindo()
    {
        Debug.Log("Oi");
        Application.Quit();
    }
}
