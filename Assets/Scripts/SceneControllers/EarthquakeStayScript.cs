using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeStayScript : MonoBehaviour
{
    private float shakeAmount = 0.1f;
    Vector3 originalCameraPos;
    private GameObject mainCamera;

    void Start()
    {

    }

    private void Awake()
    {
        GameObject sceneMaster = GameObject.FindGameObjectWithTag("SceneMaster");
        sceneMaster.GetComponent<SceneMasterScript>().SetConditionsState(true);

        mainCamera = Camera.main.gameObject;
        originalCameraPos = mainCamera.transform.localPosition;
    }

    private void Update()
    {
        Vector3 newPosition = originalCameraPos + Random.insideUnitSphere * shakeAmount;
        newPosition.z = originalCameraPos.z;
        mainCamera.transform.localPosition = newPosition;
    }

    private void OnDestroy()
    {
        mainCamera.transform.localPosition = originalCameraPos;
    }
}
