using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

    public GameObject explosionAsteroid;
     public GameObject explosionPlayer;

     private GameController  gameController;

     void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }
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
            gameController.AddScore();
            //score=score+10;

        }
        else //other=Player
        {
            Destroy(other.gameObject); //player
          //Instanciar explosão do palyer
            Instantiate(explosionAsteroid,transform.position,transform.rotation);
            //Fazer gameOver
            gameController.GameOver();
            
        }
        

        Destroy(gameObject); //asteroide

        Debug.Log("Other :"+other.name);
    }
}
