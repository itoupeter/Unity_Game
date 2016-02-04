using UnityEngine;
using System.Collections;

public class DestroyedByTime : MonoBehaviour {

    public float lifeTime;
    private GameController controller;

    private float dieTime;

    void Start() {
        dieTime = Time.time + lifeTime;
        controller = FindObjectOfType< GameController >();
    }

	void Update() {
	    if( Time.time < dieTime ) return;
        Destroy( gameObject );
        if( gameObject.tag == "Shuttle" ) ++controller.nShuttles;
	}
}
