﻿using UnityEngine;

public class MoveCycle : MonoBehaviour
{
    public Vector2 direction = Vector2.right;
    public float speed = 1f;
    public int size = 1;

    private Vector3 leftEdge;
    private Vector3 rightEdge;

    private void Start()
    {
        leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
    }

    private void OnEnable()
    {
        //If our object needs to be reset when it's respawned, such as removing existing velocity we would do that here
        //In this case we don't need to do anything
    }

    private void Update()
    {
        // Check if the object is past the right edge of the screen
        if (direction.x > 0 && (transform.position.x - size) > rightEdge.x) {
            transform.position = new Vector3(leftEdge.x - size, transform.position.y, transform.position.z);
            //Destroy(this);
        }
        // Check if the object is past the left edge of the screen
        else if (direction.x < 0 && (transform.position.x + size) < leftEdge.x) {
            transform.position = new Vector3(rightEdge.x + size, transform.position.y, transform.position.z);
            //Destroy(this);
        }
        // Move the object
        else {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

}
