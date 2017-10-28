using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMasterScript : MonoBehaviour {

    public GameObject[] scenesToLoad;

    private GameObject sceneLoaded;
    private bool conditionsMeet = false;

	// Use this for initialization
	void Start () {

        LoadScene(scenesToLoad[0]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadScene(GameObject scenePrefab)
    {
        if(sceneLoaded != null)
        {
            UnloadScene();
        }

        sceneLoaded = Instantiate(scenePrefab);
    }

    public void UnloadScene()
    {
        if(sceneLoaded != null)
        {
            GameObject.Destroy(sceneLoaded);
            sceneLoaded = null;
        }
    }

    public bool GetConditionsState()
    {
        return conditionsMeet;
    }

    public void SetConditionsSate(bool state)
    {
        conditionsMeet = state;
    }
}
