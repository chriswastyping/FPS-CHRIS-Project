using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BigEnemy : Enemy
{
    
    // Override Start method
    void Start()
    {
        base.Start(); // Call the base class Start() to ensure Rigidbody is initialized
        transform.localScale = new Vector3(3, 3, 3); // Modify size
    }

    // Override Update method
    void Update()
    {
        base.Update(); // Call base class Update() to ensure FollowPlayer() is called
    }
}