using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{

    public float movementSpeed = 10f;
    public float jumpHeight = 2f;
    public float gravityScale = 0f;
    public bool flag = false;

    //player_movement player;

    public LevelLoader level;

    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //transform.Translate(movementSpeed, 0, 0);
            rigidBody.AddForce(transform.right * movementSpeed);            
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            //transform.Translate(-movementSpeed, 0, 0);
            rigidBody.AddForce(transform.right * (-movementSpeed));
        }
        else
        {

        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle" & flag == false)
        {
            flag = true;
            Debug.Log("Player collided with obstacle");
            Debug.Log("Loading next level");
            level.LoadNextLevel();
        }
    }

    //  Load scene after trigger at the end of stage
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Reached final checkpoint");
        level.LoadEndScreen();
    }
}
