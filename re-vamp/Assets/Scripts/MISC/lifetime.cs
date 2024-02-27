using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifetime : MonoBehaviour
{
    public float LifetimeSecs = 1.0f;
    public GameObject ToDie;

    void Awake()
    {
        Destroy(ToDie, LifetimeSecs);
    }
}
