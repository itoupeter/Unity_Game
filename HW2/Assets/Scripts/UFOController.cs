using UnityEngine;
using System.Collections;

public class UFOController : MonoBehaviour {

	public GameObject bolt;
    public Transform spawnBolt;
    public float spawnBoltRate;

    void Start() {
        StartCoroutine( spawnBoltByTime() );
    }

    IEnumerator spawnBoltByTime() {
        for( ; ; ) {
            yield return new WaitForSeconds( spawnBoltRate );
            Instantiate( bolt, spawnBolt.position, spawnBolt.rotation );
        }
    }
}
