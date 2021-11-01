using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [Header("Physics")]
    [SerializeField] private Collider Col;
    [SerializeField] private Rigidbody rb;

    [Header("Speed")]
    [SerializeField] private int speed;
    [SerializeField] private int ReductionForce;
    [SerializeField] private int burstForce;
    private float acceleration;

    [Header("Rotation")]
    [SerializeField] private float rotateTime;
    [SerializeField] private float rotateSpeed;
    private float rotateElapsedTime;
    private Vector3 rotate = Vector3.zero;
    

    [SerializeField] private float maxVel;

    


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Moviment();
        Rotation();
    }

    void Moviment()
    {
         if (Input.GetAxis("Vertical") != 0 )

        {      

            if (Input.GetAxis("Vertical") > 0)
            {  
                if(Input.GetKey(KeyCode.LeftShift))
                {
                acceleration += speed * Time.deltaTime * burstForce;
                }
                else{
                    if(rb.velocity.z < 0)
                    {
                    acceleration += speed * Time.deltaTime * ReductionForce; 
                    }
                    else
                    {
                    acceleration += speed * Time.deltaTime;  
                    }
                }
                
                rb.velocity = new Vector3(rb.rotation.x,rb.velocity.y,acceleration);
                
            }
            else
            {    
                if(Input.GetKey(KeyCode.LeftShift))
                {
                acceleration += speed * Time.deltaTime * burstForce;
                }
                else
                {
                    if(rb.velocity.z > 0)
                    {
                    acceleration -= speed * Time.deltaTime * ReductionForce;  
                    }
                    else
                    {
                    acceleration -= speed * Time.deltaTime;  
                    }
                }

                rb.velocity = new Vector3(rb.rotation.x,rb.velocity.y,acceleration);

            }

        }

        else
        {
            acceleration = rb.velocity.z;
            if(Input.GetKey(KeyCode.LeftShift))
            {
            acceleration += speed * Time.deltaTime * burstForce;
            rb.velocity = new Vector3(rb.rotation.x,rb.velocity.y,acceleration);
            }
        }

    }

    void Rotation()
    {
        rotate.x = Input.GetAxis("Horizontal");

        if (rotate.x != 0)
        {
            if(rotateElapsedTime > (rotateTime/ 3))
            {
                if (rotateElapsedTime < rotateTime * 100)
                {
                    transform.rotation = Quaternion.Euler (rotate.x * Time.deltaTime * rotateSpeed, 0, 0);
                }


            }
            else
            {
                rotateElapsedTime += Time.fixedDeltaTime;
                rb.velocity = new Vector3 (rotateSpeed * rotate.x, rb.velocity.y, rb.velocity.z);
                
            }
        }

        else
        {
            rotateElapsedTime = 0;
        }

    }

    void Burst()
    {

    }




}
