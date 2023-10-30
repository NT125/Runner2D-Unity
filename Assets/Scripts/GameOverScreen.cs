using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        gameObject.SetActive(false); // La pantalla inicia desactivada
    }

    // Método para activar la pantalla
    public void ShowGameOverScreen()
    {
        gameObject.SetActive(true);
    }

    public void Restart(){
        SceneManager.LoadScene("Stage1");
    }
}
