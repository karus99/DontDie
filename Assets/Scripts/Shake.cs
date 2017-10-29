using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour {

    public int timesButton = 8;

    //shake
    // Amplitude of the shake. A larger value shakes the camera harder.
    private float shakeAmount = 0.1f;
    private float decreaseFactor = 1.0f;
    float shakeDuration = 0;
    Vector3 originalCameraPos;
    bool finished = false;

    public GameObject mainCamera;


    private void Start()
    {
       
        mainCamera = GameObject.FindObjectOfType<Camera>().gameObject;
        originalCameraPos = mainCamera.transform.localPosition;
        //ShakeCamera(0.15f, 0.15f);
    }
    void FixedUpdate()
    {

    }

    private void Update()
    {
        //new shake
        if (timesButton > 0)
        {
            Vector3 newPosition = originalCameraPos + Random.insideUnitSphere * shakeAmount;
            newPosition.z = originalCameraPos.z;
            mainCamera.transform.localPosition = newPosition;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }else if(!finished)
        {
            finished = true;
            shakeDuration = 0f;
            Vector3 position = originalCameraPos;
            position.x = mainCamera.transform.position.x;
            mainCamera.transform.localPosition = position;

            SceneMasterScript sceneMaster = GameObject.FindObjectOfType<SceneMasterScript>();
            sceneMaster.SetConditionsState(true);
            GameManagerScript gameManager = GameObject.FindObjectOfType<GameManagerScript>();
            gameManager.FinishGameScene();
        }
    }

    public void ShakeCamera(float shakePwr, float shakeDUR)
    {
        shakeAmount = shakePwr;
        
    }

    
}
