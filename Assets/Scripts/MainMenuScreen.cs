using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour
{
    // Métodos para los botones

    public void Play(){
        SceneManager.LoadScene("Stage1");
    }

    public void Quit(){
        Application.Quit(); // Sale al escritorio sólo si el juego ya es un ejecutable, no servirá desde el editor de Unity
    }
}
