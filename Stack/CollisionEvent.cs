using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionEvent : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<MeshRenderer>().material =
            this.gameObject.GetComponent<MeshRenderer>().material;
        
        collision.gameObject.GetComponent<StackCompo>().stack.Push(this.gameObject.GetComponent<MeshRenderer>().material);
    }
}
