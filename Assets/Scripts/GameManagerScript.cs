﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public RawImage timeBar;
    public GameObject sceneMaster;

    private float originalTimeToEnd = 0.0f;
    private float timeToEnd = 0.0f;

	// Use this for initialization
	void Start () {

        SetTimeToEnd(5.0f);
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(timeToEnd > 0.0f)
        {
            timeToEnd -= Time.deltaTime;

            float timeRatio = timeToEnd / originalTimeToEnd;

            timeBar.rectTransform.localScale = new Vector3(timeRatio, 1, 1);
            timeBar.color = new Color(0.37f + ((1 - timeRatio) * 0.63f), 0.37f * timeRatio, 0.37f * timeRatio);

            if(timeToEnd <= 0.0f)
            {
                OnTimeEnded();
            }
        }
	}

    void SetTimeToEnd(float time)
    {
        timeToEnd = originalTimeToEnd = time;
    }

    private void OnTimeEnded()
    {
        SceneMasterScript _sceneMaster = sceneMaster.GetComponent<SceneMasterScript>();

        _sceneMaster.UnloadScene();
        if(_sceneMaster.GetConditionsState())
        {
            Debug.Log("Conditions were met");
        }
        else
        {
            Debug.Log("Conditions were not met");
        }
        // things to do.
    }
}
