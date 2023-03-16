using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public GameObject ball;
    public float speed;

    private Vector2 velocity;

    Rigidbody2D AI;

    void Start()
    {
        AI = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
         Vector2 target = new Vector2(AI.position.x, ball.transform.position.y);
        AI.position = Vector2.MoveTowards(AI.position, target, Time.fixedDeltaTime * speed);
    }
}
