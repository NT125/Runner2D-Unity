using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMovement : MonoBehaviour
{
    [SerializeField] private float stageSpeed = 10f;
    public Rigidbody2D stageRB;

    // Game Loop
    void Start()
    {
        stageRB = GetComponent<Rigidbody2D>();
        StartCoroutine(MoveStage());
    }

    void Update()
    {
    }

    // Corrutina que mueve el escenario
    IEnumerator MoveStage()
    {
        while (true)
        {
            stageRB.transform.Translate(Vector2.left * stageSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
