using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoEvent : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<StackCompo>().stack.Count <= 0) return;
        else
        {
            other.gameObject.GetComponent<MeshRenderer>().material =
                other.gameObject.GetComponent<StackCompo>().stack.Pop();
        }
    }
}
