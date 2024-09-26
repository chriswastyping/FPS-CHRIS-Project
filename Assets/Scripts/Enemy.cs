using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   
    
    protected Transform playerTransform;
    
    [Range(15, 40)] [SerializeField] protected float speed = 25;

    protected Rigidbody _enemyRb;

    protected Vector3 _lookDirection;
    
   
    // Start is called before the first frame update
    protected void Start()
    {
        FindPlayer();
        _enemyRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    protected void Update()
    {
        // Follow the player
       FollowPlayer();
        
    }
    
    protected void FindPlayer()
    {
        playerTransform = PlayerController.Instance.transform;
    }

    protected void FollowPlayer()
    {
        _enemyRb.AddForce((playerTransform.position - transform.position).normalized * speed); 
        _enemyRb.AddForce(_lookDirection * speed);
    }
}

