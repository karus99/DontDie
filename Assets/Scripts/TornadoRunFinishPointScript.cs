using UnityEngine;
using System.Collections;

public class TornadoRunFinishPointScript : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneMasterScript sceneMaster = GameObject.FindObjectOfType<SceneMasterScript>();
        GameManagerScript gameManager = GameObject.FindObjectOfType<GameManagerScript>();
        TornadoRunSoundController soundController = GameObject.FindObjectOfType<TornadoRunSoundController>();

        sceneMaster.SetConditionsState(true);
        gameManager.FinishGameScene();
        soundController.FadeAndStopAllSounds();
    }
}
