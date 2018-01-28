using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSceneController : MonoBehaviour
{

    public Button buttonStart;
    public Button buttonExit;

	// Use this for initialization
	void Start ()
    {
        if(buttonStart != null)
            buttonStart.onClick.AddListener(delegate { StartGame(); });
        if (buttonExit != null)
            buttonExit.onClick.AddListener(delegate { ShowLeaderboards(); });
    }

    void StartGame()
    {
        GameManagerScript gameManager = GameObject.FindObjectOfType<GameManagerScript>();
        gameManager.StartGame();
        Destroy(this.gameObject);
    }

    void ShowLeaderboards() {
        GameObject.FindObjectOfType<GooglePlayScript>().ShowLeaderboards();
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
