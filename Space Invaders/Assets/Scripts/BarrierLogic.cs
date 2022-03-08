using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BarrierLogic : MonoBehaviour
{
    private int _count = 0; 
    public float scaleBy = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            if (_count < 2)
            {
                this.transform.localScale -= new Vector3(scaleBy, scaleBy, scaleBy);
                _count++;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        Destroy(collision.gameObject);
    }
}
