using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpikeEnemyTrigger : MonoBehaviour
{
    [SerializeField] private GameObject spikeEnemy;
    [SerializeField] private GameObject alert;
    [SerializeField] private float offset = 2f;
    private AudioSource alertAudio;

    void Start()
    {
        alertAudio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            StartCoroutine(LaunchAlert());
            Invoke("SpawnEnemy", 0.7f);
        }
    }

    private void SpawnEnemy(){
        Instantiate(spikeEnemy, transform.position + Vector3.left * offset, Quaternion.identity);
    }

    IEnumerator LaunchAlert(){
        alertAudio.Play();
        GameObject newAlert = Instantiate(alert, new Vector2(-7f, -1.5f), Quaternion.identity);
        yield return new WaitForSeconds(0.7f);
        Destroy(newAlert);
    }
}
