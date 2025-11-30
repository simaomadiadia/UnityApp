 using System;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    
    public Rigidbody rb;
    public GameObject shot;
    public Transform shotSpawn;

    public float xmin, xmax,zmin,zmax;    
    public float speed,tilt;
    public float fireRate = 0.5f;
    private float nextFire;

    private AudioSource shotsound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        shotsound = GetComponent<AudioSource>(); 
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
    
       //Tilt control
       rb.rotation =Quaternion.Euler(0.0f ,0.0f ,rb.linearVelocity.x* -tilt);
    }
    

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time> nextFire){

        nextFire=Time.time +fireRate;
        Instantiate(shot, shotSpawn.position,shotSpawn.rotation );
        shotsound.Play();
            
        }
    }
}
