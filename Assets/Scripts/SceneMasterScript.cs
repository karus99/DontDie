using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMasterScript : MonoBehaviour {

    public GameObject[] scenesToLoad;

    private GameObject sceneLoaded;
    private bool conditionsMeet = false;

    // scene settings
    public bool isGameScene;
    public float sceneTime;

	// Use this for initialization
	void Start ()
    {
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

        SceneSettingsScript sceneSettings = GameObject.FindObjectOfType<SceneSettingsScript>();
        isGameScene = sceneSettings.isGameScene;
        sceneTime = sceneSettings.sceneTime;
    }

    public void LoadScene(int sceneId)
    {
        LoadScene(scenesToLoad[sceneId]);
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
