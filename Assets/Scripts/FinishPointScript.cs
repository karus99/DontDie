using UnityEngine;
using System.Collections;

public class FinishPointScript : MonoBehaviour
{
    SceneMasterScript sceneMaster;
    GameManagerScript gameManager;
    SoundController soundController;
    // Use this for initialization
    void Start()
    {
        sceneMaster = GameObject.FindObjectOfType<SceneMasterScript>();
        gameManager = GameObject.FindObjectOfType<GameManagerScript>();
        soundController = GameObject.FindObjectOfType<SoundController>();
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
        soundController.FadeAndStopAllSounds();
        Debug.Log("Enter house");
    }
}
