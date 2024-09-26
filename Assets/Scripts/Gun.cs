using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    
    // Bullet

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform gunTransform;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletPrefab.transform.localRotation = new Quaternion(90, 0, 0, 0);
        
        if (Input.GetMouseButtonDown(0))
        {
            // Launch a projectile from player 
           Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);
        }
    }
}
