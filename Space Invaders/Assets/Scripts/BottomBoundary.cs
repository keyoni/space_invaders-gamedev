using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBoundary : MonoBehaviour
{
   public static event Action BottomBoundHit;
   private void OnTriggerEnter2D(Collider2D col)
   {
      if (col.CompareTag("Enemy"))
      {
         BottomBoundHit?.Invoke();
      }
   }
}
