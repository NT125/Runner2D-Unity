using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameProgressManager : MonoBehaviour
{
    public GameProgress gameProgress;
    private float delta;
    
    [SerializeField] private TextMeshProUGUI progressTMP;

    void Start()
    {
        delta = 0.2f;
        
         if (SceneManager.GetActiveScene().name == "Stage1")
        {
            gameProgress.metres = 0; // Iniciando el primer nivel con vida máxima
        }

        InvokeRepeating("MakeProgress", 0f, delta);
    }
    void Update()
    {
        Debug.Log(gameProgress.metres);
        Debug.Log("Este Log debería ejecutarse");

        progressTMP.text = "Metros Recorridos: " + gameProgress.metres.ToString() + "m";

        if (SceneManager.GetActiveScene().name == "End"){
            CancelInvoke();
            progressTMP.text = "¡Has recorrido los " + gameProgress.metres + " metros del recorrido!";
        }
    }

    private void MakeProgress(){
        gameProgress.metres += 2;
    }
}
