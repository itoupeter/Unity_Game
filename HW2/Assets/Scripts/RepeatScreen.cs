using UnityEngine;
using System.Collections;

[System.Serializable]
public class Screen {
    public float bottom, top, left, right;
}

public class RepeatScreen : MonoBehaviour {

    public Screen screen;

    private Rigidbody rb;

	void Start () {
	    rb = GetComponent< Rigidbody >();
	}
	
    void Update() {
        
        float newX = rb.position.x, newZ = rb.position.z;

        if( rb.position.x > screen.right ) {
            newX = rb.position.x - screen.right * 2;
        }else if( rb.position.x < screen.left ) {
            newX = rb.position.x + screen.right * 2;
        }

        if( rb.position.z > screen.top ) {
            newZ = rb.position.z - screen.top * 2;
        }else if( rb.position.z < screen.bottom ){
            newZ = rb.position.z + screen.top * 2;
        }

        rb.position = new Vector3( newX, 0.0f, newZ );
    }
}
