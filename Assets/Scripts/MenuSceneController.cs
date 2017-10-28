using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSceneController : MonoBehaviour {

    public Button buttonStart;
    public Button buttonExit;

	// Use this for initialization
	void Start ()
    {
        if(buttonStart != null)
            buttonStart.onClick.AddListener(delegate { StartGame(); });
        if (buttonExit != null)
            buttonStart.onClick.AddListener(delegate { ExitGame(); });
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void StartGame()
    {
        Debug.Log("clicked");
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
