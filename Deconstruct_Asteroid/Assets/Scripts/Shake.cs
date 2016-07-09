using UnityEngine;
using System.Collections;

public class Shake : MonoBehaviour {

    public bool isShaking;

    private Vector3 position;
    
    void Start() {
        isShaking = false;
        position = transform.position;
    }

	void Update() {

        if( !isShaking ) return;

        transform.position = new Vector3( 
            Mathf.Repeat( Time.time * 2, 0.1f ), 
            0, 
            Mathf.Repeat( Time.time, 0.1f )
        ) + position;
        
    }
}
