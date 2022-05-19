using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float originalX;
    private float maxOffset = 5.0f;
    private float enemyPatroltime = 2.0f;
    private float boost = 1.0f;
    private int moveRight = -1;
    private Vector2 velocity;
    private Collider2D EnemyCollider;
    private Rigidbody2D enemyBody;
    public Transform marioLocation;


    void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        // get the starting position
        originalX = transform.position.x;
        ComputeVelocity(boost);
    }
    void ComputeVelocity(float boost){
        velocity = new Vector2((moveRight)*maxOffset / enemyPatroltime * boost, 0);
    }
    void MoveGomba(){
        enemyBody.MovePosition(enemyBody.position + velocity * Time.fixedDeltaTime);
    }
    

    // Update is called once per frame
    void Update()
    {
        // change direction
        moveRight = transform.position.x - marioLocation.position.x > 0f? -1 : 1;
        boost = boost * 1.002f;
        ComputeVelocity(boost);
        MoveGomba();
    }
}
