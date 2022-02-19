using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{

    public float movementSpeed = 2f;
    public float jumpHeight = 5f;
    public float gravityScale = 1f;

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
        transform.position += new Vector3(movementSpeed, 0, 0) * Time.deltaTime * movementSpeed;

        if (Input.GetKeyDown("space") || Input.GetTouch(0).phase == TouchPhase.Began)
        {
            rigidBody.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Player collided with obstacle");
            jumpHeight = 0f;
        }
        if (collision.gameObject.tag == "floor")
        {
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
