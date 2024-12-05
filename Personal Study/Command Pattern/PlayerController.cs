using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum Dir { LEFT, RIGHT, FOWARD }
		
    public float distance = 1f;
		
    public void Movement(Dir dir)
    {
        if(dir == Dir.LEFT)
        {
            transform.Translate(Vector3.left * distance);
        }
        if(dir == Dir.RIGHT)
        {
            transform.Translate(Vector3.right* distance);
        }
        if(dir == Dir.FOWARD )
        {
            transform.Translate(Vector3.forward * distance);
        }
    }
}