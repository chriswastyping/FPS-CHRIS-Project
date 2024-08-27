using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
   public GameObject enemyHit;
  // public GameObject bullet;
   private void OnTriggerEnter(Collider other)
   {
      if (other.tag == "Enemy") 
      {
         Destroy(enemyHit);
      }
   }
}
