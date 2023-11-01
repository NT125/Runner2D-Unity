using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeEnemyMovement : MonoBehaviour
{
     [SerializeField] public float movementSpeed = 18.5f;
    [SerializeField] private Rigidbody2D spikeEnemyRB;

    void Start()
    {
        spikeEnemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Delete();
    }

    private void Move()
    {
        spikeEnemyRB.transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
    }

    private void Delete()
    {
        if (spikeEnemyRB.transform.position.x >= 11f)
        {
            Destroy(gameObject);
        }
    }
}
