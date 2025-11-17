using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    
    public Rigidbody rb;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
     
     void FixedUpdate()
    {
        float moveH =Input.GetAxis("Horizontal");
        float moveV =Input.GetAxis("Vertical");
        Vector3 moviment = new Vector3(moveH,0.0f,moveV);
        rb.linearVelocity = moviment *speed;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
