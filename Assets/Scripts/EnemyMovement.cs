using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] public float movementSpeed = 7f;
    [SerializeField] private Rigidbody2D enemyRB;

    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Delete();
    }

    private void Move()
    {
        enemyRB.transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
    }

    private void Delete()
    {
        if (enemyRB.transform.position.x <= -11f)
        {
            Destroy(gameObject);
        }
    }
}
