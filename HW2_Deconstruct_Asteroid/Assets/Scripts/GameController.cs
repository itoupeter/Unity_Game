using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public int ASTEROID_SCORE;
    public int SHUTTLE_SCORE;
    public int nAsteroids;
    public int nPlayers;
    public int nLives;
    public int score;
    public GameObject asteroid;
    public GameObject player;
    public GameObject UFO;
    public Transform spawnUFO;
    public float spawnUFOWait;
    public GameObject shuttle;
    public Transform spawnShuttle;
    public float spawnShuttleWait;
    public Text textScore;
    public Text textLife;
    public int nShuttles;
    public int cameraID;
    
    private GameObject background;
    private Camera[] cameras;
    private bool isMainCamera;
    private int level;
    
    void Start() {
        background = GameObject.FindWithTag( "Background" );
        StartCoroutine( spawnUFOByTime() );
        StartCoroutine( spawnShuttleByTime() );
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

        if( Input.GetButtonDown( "Fire2" ) ) {
            //---switch camera---
            if( cameraID == 0 )
                UnityEngine.SceneManagement.SceneManager.LoadScene( "Main3D" );
            else
                UnityEngine.SceneManagement.SceneManager.LoadScene( "Main" );
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
            yield return new WaitForSeconds( spawnUFOWait );
            Instantiate( UFO, spawnUFO.position, spawnUFO.rotation );
        }
    }

    IEnumerator spawnShuttleByTime() {
        for( ; ; ) {
            for( int i = 0; i < 3; ++i ) {
                Instantiate( shuttle, spawnShuttle.position, spawnShuttle.rotation );
                yield return new WaitForSeconds( 2 );
            }
            StartCoroutine( checkShuttles() );
            yield return new WaitForSeconds( spawnShuttleWait );
        }
    }

    IEnumerator checkShuttles() {
        
        yield return new WaitForSeconds( 14 );

        if( nShuttles == 0 )
            --nLives;
        else if( nShuttles == 3 )
            ++nLives;
        else
           score += SHUTTLE_SCORE * nShuttles;

        nShuttles = 0;
    }
}
