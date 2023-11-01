using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeEnemyTrigger : MonoBehaviour
{
    [SerializeField] private GameObject spikeEnemy;
    [SerializeField] private float offset = 2f;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("Hay colisión");
            //Vector2 spawnLocation = transform.position + Vector3.left * offset; // Creando un punto de spawn, "offset" unidades a la derecha
            Invoke("SpawnEnemy", 0.7f);
        }
    }

    private void SpawnEnemy(){
        Instantiate(spikeEnemy, transform.position + Vector3.left * offset, Quaternion.identity);
    }
}
