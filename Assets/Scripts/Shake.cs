using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour {

    public Vector2 velocity;
    public float smoothTimeY;
    public float smoothTimeX;
    public float shakePwr, shakeDUR;
    public int timesButton = 5;

    //shake
    // Amplitude of the shake. A larger value shakes the camera harder.
    private float shakeAmount = 0.1f;
    private float decreaseFactor = 1.0f;
    float shakeDuration = 0;
    Vector3 originalCameraPos;

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
        }else
        {
            shakeDuration = 0f;
            Vector3 position = originalCameraPos;
            position.x = mainCamera.transform.position.x;
            mainCamera.transform.localPosition = position;
        }

        //old shake
        //if(timesButton>0)
        //{
        //    Vector2 ShakePos = Random.insideUnitCircle * shakeAmount;
        //    MainCamera.transform.position = new Vector3(MainCamera.transform.position.x + ShakePos.x, MainCamera.transform.position.y + ShakePos.y, MainCamera.transform.position.z);
        //}
        //else
        //{
        //    GameObject sceneMaster = GameObject.FindGameObjectWithTag("SceneMaster");
        //    sceneMaster.GetComponent<SceneMasterScript>().SetConditionsState(true);
        //}

    }

    public void ShakeCamera(float shakePwr, float shakeDUR)
    {
        shakeAmount = shakePwr;
        
    }

    
}
