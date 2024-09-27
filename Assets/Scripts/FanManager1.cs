using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanManager1 : MonoBehaviour
{
    public GameObject Baloon;
    public float rotationSpeed = 20f;
    public float blowForce = 0.001f;
    public float blowDistance = 2f;
    public bool baloonIsBlowed;
    public AudioSource flapSound;
    void Start()
    {
        
    }

    void Update()
    {
       
            if (Baloon != null)
            {
                baloonRotation();
                applyBlowEffect();
            }

            if (Input.GetMouseButton(0))
            {

                 baloonMovement();
            }
      
    }

    private void FixedUpdate()
    {
        applyBlowEffect();
    }

    private void baloonRotation()
    {
        Vector3 direction = Baloon.transform.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void baloonMovement()
    {
        Vector3 MouseScreenPosition = Input.mousePosition;

        Vector3 MouseWorldPosition = Camera.main.ScreenToWorldPoint(MouseScreenPosition);

        MouseWorldPosition.z = 0;

        transform.position = MouseWorldPosition;
        flapSound.Play();

    }

    private void applyBlowEffect()
    {
        float distance = Vector3.Distance(Baloon.transform.position, transform.position);
        if (distance < blowDistance)
        {
            Vector3 blowDirection = (Baloon.transform.position - transform.position).normalized;

            Rigidbody2D baloonRB = Baloon.GetComponent<Rigidbody2D>();

            if (baloonRB != null)
            {
                baloonRB.AddForce(blowDirection * blowForce);
                baloonIsBlowed = true;
            }
            
        }
        else
        {
            baloonIsBlowed = false;
        }
    }

}
