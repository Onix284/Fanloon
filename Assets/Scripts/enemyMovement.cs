using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public float enemyMovementSpeed = 2f;
    public Transform transform;
    public float rotationSpeed = 100f;
    //public BaloonManager baloonManager;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -enemyMovementSpeed * Time.deltaTime, 0);
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        if (transform.position.y < -4)
        {
            Destroy(gameObject);
        }
        
    }

}
