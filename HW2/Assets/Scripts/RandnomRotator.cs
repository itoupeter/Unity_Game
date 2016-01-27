using UnityEngine;
using System.Collections;

public class RandnomRotator : MonoBehaviour {

    public float tumble;

    private Rigidbody rb;

    void Start() {
        rb = GetComponent< Rigidbody >();
        rb.angularVelocity = tumble * Random.insideUnitSphere;
    }
}
