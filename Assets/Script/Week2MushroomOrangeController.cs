using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week2MushroomOrangeController : MonoBehaviour
{
    private float originalX;
    private float maxOffset = 5.0f;
    private int moveRight = -1;
    private Vector2 velocity;
    private Collider2D EnemyCollider;
    private Rigidbody2D enemyBody;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player")==false && col.gameObject.CompareTag("Ground")==false && col.gameObject.CompareTag("Obstacles")==false)
        {
            moveRight = -moveRight;
        };
        if (col.gameObject.CompareTag("Player")){
            moveRight = 0;
            Destroy(GameObject.Find("MushroomOrange(Clone)"));
        }
    }
    void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        // get the starting position
        originalX = transform.position.x;
        ComputeVelocity();
    }
    void ComputeVelocity(){
        velocity = new Vector2((moveRight)*maxOffset, 0);
    }
    void MoveGomba(){
        enemyBody.MovePosition(enemyBody.position + velocity * Time.fixedDeltaTime);
    }
    

    // Update is called once per frame
    void Update()
    {
        // change direction
        
        ComputeVelocity();
        MoveGomba();
    }
}
