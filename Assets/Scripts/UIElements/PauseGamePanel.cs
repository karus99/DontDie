using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGamePanel : MonoBehaviour {

    GameManagerScript gameManager;
    public Button quitButton;
    public Button resumeButton;
	// Use this for initialization
	void Start () {
        gameManager = GameObject.FindObjectOfType<GameManagerScript>();

        quitButton.onClick.AddListener(delegate { 
                gameManager.PauseGame(false);
                gameManager.LoadMainMenuScene();
            });
        resumeButton.onClick.AddListener(delegate { gameManager.PauseGame(false); });
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
