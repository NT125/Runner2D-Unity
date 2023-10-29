using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float offset = 15f;

    // Al colisionar con el jugador, instancia un enemigo a la derecha
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Vector2 spawnLocation = transform.position + Vector3.right * offset; // Creando un punto de spawn, "offset" unidades a la derecha
            Instantiate(enemy, spawnLocation, Quaternion.identity); // Instanciando al enemigo
        }
    }
}
