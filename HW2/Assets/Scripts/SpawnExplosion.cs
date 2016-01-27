using UnityEngine;
using System.Collections;

public class SpawnExplosion : MonoBehaviour {

    public GameObject explosion;
    public string hitObject;

    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    public void OnTriggerEnter(Collider other) {
        if( other.tag == "Asteroid" ) {
            Instantiate( explosion, rb.position, rb.rotation );
        }
    }
}
