using UnityEngine;
using System.Collections;

public class ThunderEffect : MonoBehaviour {

    private FighterController player;

    void Start() {
        player = FindObjectOfType< FighterController >();
    }

    public void OnTriggerEnter(Collider other) {
        if( other.tag != "Player" ) return;
        Destroy( gameObject );
        player.fireRate *= 0.5f;
    }
}
