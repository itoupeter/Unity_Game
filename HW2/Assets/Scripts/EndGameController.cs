using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndGameController : MonoBehaviour {

    public Text playerName;
    
	public void OnAgainClicked() {

        int newScore = PlayerPrefs.GetInt( "new_score" );
        string[] names = new string[ 5 ];
        int[] scores = new int[ 5 ];
        int j = 5;

        for( int i = 4; i >= 0; --i ) {
            names[ i ] = PlayerPrefs.GetString( "name" + ( i + 1 ) );
            scores[ i ] = PlayerPrefs.GetInt( "score" + ( i + 1 ) );
            if( newScore > scores[ i ] ) j = i;
        }

        for( int i = 4; i > j; --i ) {
            names[ i ] = names[ i - 1 ];
            scores[ i ] = scores[ i - 1 ];
        }

        if( j < 5 ) {
            names[ j ] = playerName.text;
            scores[ j ] = newScore;
        }

        for( int i = 0; i < 5; ++i ) {
            PlayerPrefs.SetInt( "score" + ( i + 1 ), scores[ i ] );
            PlayerPrefs.SetString( "name" + ( i + 1 ), names[ i ] );
        }
        
        UnityEngine.SceneManagement.SceneManager.LoadScene( "Start" );
    }
}
