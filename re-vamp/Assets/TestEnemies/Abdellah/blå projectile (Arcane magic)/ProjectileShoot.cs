using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    // Start is called before the first frame update
    public ProjectileBehaviour ProjectilePrefab;
    public Transform Launcher;
    private float timer = 0f;
    private float interval = 5f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            transform.Rotate(new Vector3(0, 0, UnityEngine.Random.Range(0, 380)), Space.Self);
            Instantiate(ProjectilePrefab, Launcher.position, transform.rotation);   

            
            timer = 0f;
        }
    }
}
