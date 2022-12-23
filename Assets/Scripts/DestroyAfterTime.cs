using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] float timeToDestroy = 20.0f;

    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }
}
