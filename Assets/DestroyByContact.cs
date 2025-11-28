using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

    public GameObject explosionAsteroid;
     public GameObject explosionPlayer;
    void OnTriggerEnter(Collider other)
    {
 
     
        if (other.tag== "Boundary")
        {
            return;
        }
        else if (other.tag=="Shot")
        {
            Destroy(other.gameObject); //shot
            //Instanciar explosão do asteroide
            Instantiate(explosionPlayer,other.transform.position,other.transform.rotation);
            //adicionar score 
            //score=score+10;

        }
        else //other=Player
        {
            Destroy(other.gameObject); //player
          //Instanciar explosão do palyer
            Instantiate(explosionAsteroid,transform.position,transform.rotation);
            //Fazer gameOver
            
        }
        

        Destroy(gameObject); //asteroide

        Debug.Log("Other :"+other.name);
    }
}
