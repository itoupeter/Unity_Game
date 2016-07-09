using UnityEngine;
using System.Collections;

public class DropItems : MonoBehaviour {

	public GameObject thunder;

    void Start() {
        if( Random.value > 0.5f ) StartCoroutine( dropItems() );
    }

    IEnumerator dropItems() {
        
        yield return new WaitForSeconds( 7.5f );

        Vector2 velocity = Random.insideUnitCircle * 15;
        GameObject go = Instantiate( thunder, new Vector3(), new Quaternion() ) as GameObject;
        Rigidbody rb = go.GetComponent< Rigidbody >();
        
        rb.velocity = new Vector3( velocity.x, 0, velocity.y );
    }
}
