using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end_level_movement : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }
}
