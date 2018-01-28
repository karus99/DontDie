using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.UI;

public class GooglePlayScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        SingIn();

    }

    void SingIn() {
       
        if (!PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.Authenticate((bool success) => {
                if (success)
                {
                    Debug.Log("Signed in to GooglePlay as " + PlayGamesPlatform.Instance.GetUserDisplayName());
                }
                else
                {
                    Debug.Log("Error signing in to GooglePlay");
                }
            }, false);   /// <--- That "true" is very important!
        }
        else
        {
            Debug.Log("We're already signed in");
        }
    }


    public void ShowLeaderboards()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI();
        }
        else {
            Debug.Log("Error showing leaderboards. User not logged.");
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
