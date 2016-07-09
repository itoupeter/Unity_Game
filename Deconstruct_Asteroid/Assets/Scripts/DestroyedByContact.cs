using UnityEngine;
using System.Collections;

public class DestroyedByContact : MonoBehaviour {
    
    public GameObject hitObject;
    public GameObject explosion;
    public GameObject split;

    private GameController controller;
    private Rigidbody rb;
    private Renderer renderer;

    void Start() {
        controller = FindObjectOfType< GameController >();
        rb = GetComponent< Rigidbody >();
        renderer = GetComponent< Renderer >();
    }

    void OnTriggerEnter(Collider other) {
        
        if( other.tag != hitObject.tag ) return;
        
        Destroy( gameObject );
        if(tag == "Asteroid") {
            --controller.nAsteroids;
            controller.score += controller.ASTEROID_SCORE;
        } else if( tag == "UFO" ) {
            controller.score += controller.ASTEROID_SCORE * 5;
        } else if( tag == "Player" ) {
            --controller.nPlayers;
        }

        if(explosion == null) return;
        
        Instantiate( explosion, rb.transform.position, rb.transform.rotation );

        if( split == null ) return;

        Instantiate( split, rb.transform.position, rb.transform.rotation );
        Instantiate( split, rb.transform.position, rb.transform.rotation );
        Instantiate( split, rb.transform.position, rb.transform.rotation );
        controller.nAsteroids += 3;
    }
}
