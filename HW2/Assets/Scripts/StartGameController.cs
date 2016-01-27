using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class StartGameController : MonoBehaviour {

    public Text highScore;
    
    void Start() {

        string text = "";

        for( int i = 1; i <= 5; ++i ) {
            if( PlayerPrefs.HasKey( "score" + i ) ) {
                text += i + ". " + PlayerPrefs.GetInt( "score" + i ) + " " + PlayerPrefs.GetString( "name" + i ) + "\n";
            } else {
                text += i + ". 0 Player\n";
            }
        }

        highScore.text = text;
    }

	public void onStartClicked() {
        UnityEngine.SceneManagement.SceneManager.LoadScene( "Main" );
    }
}
