using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent : MonoBehaviour
{
    [SerializeField] Transform parent;

    public void ParentAndPosition()
    {
        transform.parent = parent;
        transform.position = parent.position;
        transform.rotation = parent.rotation;
    }
}
