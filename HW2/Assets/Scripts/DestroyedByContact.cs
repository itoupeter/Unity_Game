using UnityEngine;
using System.Collections;

public class DestroyedByContact : MonoBehaviour {
    
    public GameObject hitObject;
    public GameObject explosion;
    public GameObject split;
    public float phantomModeLength;
    private float phantomModeEnd;

    private GameController controller;
    private Rigidbody rb;

    void Start() {
        controller = FindObjectOfType< GameController >();
        rb = GetComponent< Rigidbody >();
    }

    void OnTriggerEnter(Collider other) {

        if(other.tag != hitObject.tag ) return;
        
        Destroy( gameObject );
        if(tag == "Asteroid") {
            --controller.nAsteroids;
            controller.score += controller.ASTEROID_SCORE;
        } else if( tag == "Player" ) {
            --controller.nPlayers;
            phantomModeEnd += phantomModeLength + Time.time;
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
