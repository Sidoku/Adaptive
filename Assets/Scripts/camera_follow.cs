using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour
{

    public Transform target;
    public float followSpeed = 0.5f ;
    public float yMin = 0f;
    public Vector3 offset;
    Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 clampedPosition = new Vector3(targetPosition.x, Mathf.Clamp(targetPosition.y, yMin, float.MaxValue), targetPosition.z);
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, clampedPosition, ref velocity, followSpeed *Time.deltaTime);

        transform.position = smoothPosition;
    }

}
