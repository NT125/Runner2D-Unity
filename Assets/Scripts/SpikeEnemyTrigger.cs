using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpikeEnemyTrigger : MonoBehaviour
{
    [SerializeField] private GameObject spikeEnemy;
    [SerializeField] private GameObject alert;
    [SerializeField] private float offset = 2f;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            StartCoroutine(LaunchAlert());
            Debug.Log("Hay colisión");
            //Vector2 spawnLocation = transform.position + Vector3.left * offset; // Creando un punto de spawn, "offset" unidades a la derecha
            Invoke("SpawnEnemy", 0.7f);
        }
    }

    private void SpawnEnemy(){
        Instantiate(spikeEnemy, transform.position + Vector3.left * offset, Quaternion.identity);
    }

    IEnumerator LaunchAlert(){
        GameObject newAlert = Instantiate(alert, new Vector2(-7f, -1.5f), Quaternion.identity);
        yield return new WaitForSeconds(0.7f);
        Destroy(newAlert);
    }
}
