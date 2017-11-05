using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeElevatorScript: MonoBehaviour {

    public int buttonsLeft = 8;

    // Shake
    // Amplitude of the shake. A larger value shakes the camera harder.
    private float shakeAmount = 0.1f;
    Vector3 originalCameraPos;
    GameObject mainCamera;

    private void Start()
    {
        mainCamera = Camera.main.gameObject;
        originalCameraPos = mainCamera.transform.localPosition;
    }

    private void Update()
    {
        // Shake effect
        if (buttonsLeft > 0)
        {
            Vector3 newPosition = originalCameraPos + Random.insideUnitSphere * shakeAmount;
            newPosition.z = originalCameraPos.z;
            mainCamera.transform.localPosition = newPosition;
        }
        else
        {
            mainCamera.transform.localPosition = originalCameraPos;

            SceneMasterScript sceneMaster = GameObject.FindObjectOfType<SceneMasterScript>();
            sceneMaster.SetConditionsState(true);
            GameManagerScript gameManager = GameObject.FindObjectOfType<GameManagerScript>();
            gameManager.FinishGameScene();

            Destroy(this);
        }
    }
}
