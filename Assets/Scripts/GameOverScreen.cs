using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
