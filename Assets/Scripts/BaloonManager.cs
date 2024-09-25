using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonManager : MonoBehaviour
{
 
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
        }
    }
}
