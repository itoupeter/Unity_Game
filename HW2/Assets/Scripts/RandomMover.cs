using UnityEngine;
using System.Collections;

public class RandomMover : MonoBehaviour {
    
    public float maxSpeed;

	private Rigidbody rb;

    void Start() {
        rb = GetComponent< Rigidbody >();
        
        Vector2 circle = Random.insideUnitCircle;
        Vector3 speed = new Vector3( circle.x, 0.0f, circle.y );

        rb.velocity = maxSpeed * speed;
    }
}
