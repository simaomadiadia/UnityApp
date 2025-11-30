using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{

    // causado do problema
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
        Debug.Log("Destroyed: " + other.name);  
    }
}
