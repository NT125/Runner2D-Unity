using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMovement : MonoBehaviour
{
    [SerializeField] private float stageSpeed = 10f;
    public Rigidbody2D stageRB;

    // Start is called before the first frame update
    void Start()
    {
        stageRB = GetComponent<Rigidbody2D>();
        StartCoroutine(MoveStage());
    }

    // Update is called once per frame
    void Update()
    {
    }

    /* void MoveStage(){
        stageRB.transform.Translate(Vector2.left * stageSpeed * Time.deltaTime);
    } */

    IEnumerator MoveStage(){
        while(true){
            stageRB.transform.Translate(Vector2.left * stageSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
