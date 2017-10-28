using UnityEngine;
using System.Collections;

public class FinishPointScript : MonoBehaviour
{
    SceneMasterScript sceneMaster;
    GameManagerScript gameManager;
    // Use this for initialization
    void Start()
    {
        sceneMaster = GameObject.FindObjectOfType<SceneMasterScript>();
        gameManager = GameObject.FindObjectOfType<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sceneMaster.SetConditionsState(true);
        gameManager.FinishGameScene();
        Debug.Log("Enter house");
    }
}
