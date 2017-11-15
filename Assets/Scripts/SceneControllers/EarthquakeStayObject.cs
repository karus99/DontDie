using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeStayObject : MonoBehaviour {

    private void OnMouseDown()
    {
        GameObject sceneMaster = GameObject.FindGameObjectWithTag("SceneMaster");
        sceneMaster.GetComponent<SceneMasterScript>().SetConditionsState(false);
        GameManagerScript gameManager = GameObject.FindObjectOfType<GameManagerScript>();
        gameManager.FinishGameScene();
    }
}
