using System;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    
    public Rigidbody rb;

    public float xmin, xmax,zmin,zmax;    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        
    }
     
     void FixedUpdate()
    {
        //moviment Control
        float moveH =Input.GetAxis("Horizontal");
        float moveV =Input.GetAxis("Vertical");
        Vector3 moviment = new Vector3(moveH,0.0f,moveV);
        rb.linearVelocity = moviment *speed;

        // area control
        rb.position= new Vector3(Math.Clamp(rb.position.x,xmin,xmax) ,0.0f, Math.Clamp(rb.position.z,zmin,zmax));
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
