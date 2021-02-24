using UnityEngine;

public class Car : Game
{
    
    
    private void Awake()
    {
        app.car = gameObject.GetComponent<Car>();
        app.data.carRb = gameObject.GetComponent<Rigidbody>();
        app.data.arrowTr = gameObject.GetComponentsInChildren<Transform>();

    }
    private void Start()
    {
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Crash"))
        {
            app.data.carRb.position = app.data.respawnPosition;
            app.data.carRb.rotation = app.data.respawnRotation;
            app.data.carRb.velocity = app.data.respawnVelocity;
            Debug.Log("You crash car!");
            
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            app.data.stopProgress = true;
            app.data.progress = 100;
            app.data.carRb.velocity = Vector3.zero;
            app.ui.FinalMenuOpen();
        }
    }

}
