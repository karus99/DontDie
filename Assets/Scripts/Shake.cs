using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour {

    public Vector2 velocity;
    public float smoothTimeY;
    public float smoothTimeX;
    public float shakePwr, shakeDUR;
    public int timesButton = 5;

    public GameObject MainCamera;

   
    public float shakeAmount;
    private void Start()
    {
        MainCamera = GameObject.FindObjectOfType<Camera>().gameObject;
        ShakeCamera(0.15f, 0.15f);
    }
    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, MainCamera.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, MainCamera.transform.position.x, ref velocity.y, smoothTimeY);

        MainCamera.transform.position = new Vector3(posX, posY, MainCamera.transform.position.z);

    }

    private void Update()
    {
        if(timesButton>0)
        {
            Vector2 ShakePos = Random.insideUnitCircle * shakeAmount;
            MainCamera.transform.position = new Vector3(MainCamera.transform.position.x + ShakePos.x, MainCamera.transform.position.y + ShakePos.y, MainCamera.transform.position.z);
        }
        else
        {
            GameObject sceneMaster = GameObject.FindGameObjectWithTag("SceneMaster");
            sceneMaster.GetComponent<SceneMasterScript>().SetConditionsSate(true);
        }
      
    }

    public void ShakeCamera(float shakePwr, float shakeDUR)
    {
        shakeAmount = shakePwr;
        
    }

    
}
