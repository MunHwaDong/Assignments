using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMovement : MonoBehaviour
{
    public float movementSpeed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.zero;
        
        if (Input.GetKey(KeyCode.W))
        {
            dir += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            dir -= transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            dir -= transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dir += transform.right;
        }
        
        transform.position += dir * movementSpeed * Time.deltaTime;
    }
}
