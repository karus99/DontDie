using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {
    private GameObject player;
    PlayerScript playerScript;
    // Use this for initialization
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerScript>();
    }


  
    // Update is called once per frame
    void Update() {

        for(int i = 0; i < Input.touchCount; i ++)
        {
            // touch on screen
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Debug.Log("Touch detected");
                movePlayerLeft();

            }
        }
        
    }


    public void movePlayerLeft() {
        playerScript.voidAddForceLeft();
    }
}
