using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    
    // Bullet

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform gunTransform;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Launch a projectile from player 
           Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);
        }
    }
}
