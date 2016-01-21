using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

    public float turnSpeed;
    public float thrustSpeed;

	// Use this for initialization
	void Start () {
        turnSpeed = .5f;
        thrustSpeed = .01f;
	}
	
	// Update is called once per frame
	void Update () {

        if( Input.GetAxisRaw( "Vertical" ) > 0 ){
            gameObject.transform.Translate( 0, 0, thrustSpeed );
        }

        if( Input.GetAxisRaw( "Horizontal" ) < 0 ){
            gameObject.transform.Rotate( 0, turnSpeed, 0 );
        }else if( Input.GetAxisRaw( "Horizontal" ) > 0 ) {
            gameObject.transform.Rotate( 0, -turnSpeed, 0 );
        }
    }
}
