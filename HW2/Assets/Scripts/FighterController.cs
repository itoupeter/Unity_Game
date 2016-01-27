using UnityEngine;
using System.Collections;

public class FighterController : MonoBehaviour {
    
    public GameObject bolt;
    public Transform spawnBolt;
    public float fireRate;
    public float speed;
    public float rotateSpeed;

    private Rigidbody rb;
    private AudioSource audio;
    private float nextFire;

	void Start () {
	    rb = GetComponent< Rigidbody >();
        audio = GetComponent< AudioSource >();
	}
	
	void Update () {
	    if( Input.GetButton( "Fire1" ) && Time.time > nextFire ) {
            nextFire = Time.time + fireRate;
            Instantiate( bolt, spawnBolt.position, spawnBolt.rotation );
            audio.Play();
        }

        float vertical = Input.GetAxis( "Vertical" );
        if( vertical > 0 ){
            Vector3 newVelocity = rb.velocity + speed * rb.transform.forward;
            rb.velocity = newVelocity;
        }
        
        float horizontal = Input.GetAxis( "Horizontal" );
        Vector3 omega = new Vector3( 0.0f, rotateSpeed * horizontal, 0.0f );
        rb.angularVelocity = omega;
	}
}
