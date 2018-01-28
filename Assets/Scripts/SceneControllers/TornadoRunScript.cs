using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoRunScript : MonoBehaviour
{
    private GameObject player;
    TornadoRunPlayerScript playerScript;

    // Use this for initialization
    void Start()
    {

    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<TornadoRunPlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_ANDROID
        for (int i = 0; i < Input.touchCount; i++)
        {
            // touch on screen
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                movePlayerLeft();
                break;
            }
        }
#endif

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            movePlayerLeft();
        }
#endif
    }

    private void movePlayerLeft()
    {
        if (playerScript == null) playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<TornadoRunPlayerScript>();
        playerScript.MoveLeft();
    }
}
