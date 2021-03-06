﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMasterScript : MonoBehaviour {

    public GameObject[] scenesToLoad;
    public GameObject mainMenuScene;

    private GameObject loadedScenePrefab;
    private GameObject sceneLoaded;
    private SceneSettingsScript sceneSettingsLoaded;
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
        SetConditionsState(false);

        if (sceneLoaded != null)
        {
            UnloadScene();
        }
        loadedScenePrefab = scenePrefab;
        sceneLoaded = Instantiate(scenePrefab);

        sceneSettingsLoaded = GameObject.FindObjectOfType<SceneSettingsScript>();
        if(sceneSettingsLoaded)
        {
            isGameScene = sceneSettingsLoaded.isGameScene;
            sceneTime = sceneSettingsLoaded.sceneTime;
        }
        else
        {
            isGameScene = false;
        }
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

    public void SetConditionsState(bool state)
    {
        conditionsMeet = state;
    }

    public void LoadNextRandomScene() {
        GameObject nextScene;
        do
        {
            int sceneId = Random.Range(0, scenesToLoad.Length);
            nextScene = scenesToLoad[sceneId];
        } while (scenesToLoad.Length>1 && nextScene.Equals(loadedScenePrefab));
        LoadScene(nextScene);
    }
    public void RepeatScene()
    {
        LoadScene(loadedScenePrefab);

    }
    public void LoadMainMenuScene()
    {
        LoadScene(mainMenuScene);
    }

    public SceneSettingsScript GetSceneSettingsScript() {
        return sceneSettingsLoaded;
    }

}
