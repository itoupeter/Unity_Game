using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public int ASTEROID_SCORE;
    public int nAsteroids;
    public int nPlayers;
    public int nLives;
    public int score;
    public GameObject asteroid;
    public GameObject player;
    public GameObject UFO;
    public Transform spawnUFO;
    public float spawnUFOWait;
    public Text textScore;
    public Text textLife;

    private int level;
    
    void Start() {
        StartCoroutine( spawnUFOByTime() );
    }

	void Update () {
	    if( nAsteroids == 0 ) {
            nAsteroids = ++level;
            spawnAsteroids();
        }

        if( nPlayers == 0 ) {
            if( nLives == 0 ) {
                PlayerPrefs.SetInt( "new_score", score );
                UnityEngine.SceneManagement.SceneManager.LoadScene( "End" );
            }else {
                --nLives;
                ++nPlayers;
                Instantiate( player, new Vector3(), new Quaternion() );
            }
        }

        textScore.text = "" + score;
        textLife.text = "" + nLives;
	}

    void spawnAsteroids() {
        for( int i = 0; i < level; ++i ) {

            Vector2 circle = Random.insideUnitCircle.normalized * 10;
            Vector3 position = new Vector3( circle.x, 0.0f, circle.y );
            Quaternion rotation = new Quaternion();

            Instantiate( asteroid, position, rotation );
        }
    }

    IEnumerator spawnUFOByTime() {
        for( ; ; ) {
            Instantiate( UFO, spawnUFO.position, spawnUFO.rotation );
            yield return new WaitForSeconds( spawnUFOWait );
        }
    }
}
