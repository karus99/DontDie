using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthQuakeSceneScripts : MonoBehaviour {
    private float shakeAmount = 0.1f;
    private float decreaseFactor = 1.0f;
    Vector3 originalCameraPos;
    bool finished = false;
    // Use this for initialization
    private GameObject mainCamera;
    void Start() {
        GameObject sceneMaster = GameObject.FindGameObjectWithTag("SceneMaster");
        sceneMaster.GetComponent<SceneMasterScript>().SetConditionsState(true);

        mainCamera = GameObject.FindObjectOfType<Camera>().gameObject;
        originalCameraPos = mainCamera.transform.localPosition;
    }



    private void Update()
    {
        if (!finished)
        {
            Vector3 newPosition = originalCameraPos + Random.insideUnitSphere * shakeAmount;
            newPosition.z = originalCameraPos.z;
            mainCamera.transform.localPosition = newPosition;
        }
        else if (finished){
            finished = true;
            Vector3 position = originalCameraPos;
            position.x = mainCamera.transform.position.x;
            mainCamera.transform.localPosition = position;

            SceneMasterScript sceneMaster = GameObject.FindObjectOfType<SceneMasterScript>();
            sceneMaster.SetConditionsState(true);
            GameManagerScript gameManager = GameObject.FindObjectOfType<GameManagerScript>();
            gameManager.FinishGameScene();
        }

    }


}
