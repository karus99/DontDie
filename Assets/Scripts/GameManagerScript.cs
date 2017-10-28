using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public GameObject prefabTimeBar;

    // Buttons
    public GameObject prefabMainMenuPanel;

    public GameObject sceneMaster;

    private float originalTimeToEnd = 0.0f;
    private float timeToEnd = 0.0f;
    private RawImage timeBar;
    private GameObject MainManuPanel;
    private bool gameStarted = false;
    SceneMasterScript sceneMasterScript;

    public GameObject endGamePanelPrefab;
    private GameObject endGamePanel;

    // Use this for initialization
    void Start ()
    {
        sceneMasterScript = sceneMaster.GetComponent<SceneMasterScript>();

<<<<<<< HEAD
        LoadNextScene();
        //sceneMasterScript.LoadScene(0);
        
=======
        sceneMasterScript.LoadScene(0);
        SetTimeToEnd(sceneMasterScript.sceneTime);

        if(sceneMasterScript.isGameScene)
        {
            GameObject _timeBar = Instantiate(prefabTimeBar, GameObject.FindObjectOfType<Canvas>().GetComponent<Transform>());
            timeBar = _timeBar.transform.GetChild(0).GetComponent<RawImage>();

            gameStarted = true;
        }
        else // menu scene
        {
            MainManuPanel = Instantiate(prefabMainMenuPanel, GameObject.FindObjectOfType<Canvas>().GetComponent<Transform>());
        }
>>>>>>> origin/master
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(timeToEnd > 0.0f && gameStarted)
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
        ShowEndGamePanel();
        // things to do.
    }

    private void AddTimeBar() {
        if (timeBar != null) {
            Destroy(timeBar.transform.parent.gameObject);
        }

        if (sceneMasterScript.isGameScene)
        {
            
            GameObject _timeBar = Instantiate(prefabTimeBar, GameObject.FindObjectOfType<Canvas>().GetComponent<Transform>());
            timeBar = _timeBar.transform.GetChild(0).GetComponent<RawImage>();

            gameStarted = true;
        }
    }

    public void LoadNextScene() {
        sceneMasterScript.LoadNextRandomScene();
        SetTimeToEnd(sceneMasterScript.sceneTime);
        AddTimeBar();
        if (endGamePanel != null) Destroy(endGamePanel);
    }
    public void RepeatScene() {
        sceneMasterScript.RepeatScene();
        SetTimeToEnd(sceneMasterScript.sceneTime);
        AddTimeBar();
        if (endGamePanel != null) Destroy(endGamePanel);
    }
    public void LoadMainMenuScene() {
        sceneMasterScript.LoadMainMenuScene();
        if (endGamePanel != null) Destroy(endGamePanel);
    }

    public void ShowEndGamePanel()
    {
        if (endGamePanel != null) Destroy(endGamePanel);
        Transform parent = GameObject.FindObjectOfType<Canvas>().transform;
        endGamePanel = Instantiate(endGamePanelPrefab, parent);
        SceneSettingsScript sceneSettings = sceneMasterScript.GetSceneSettingsScript();
        endGamePanel.GetComponent<EndGamePanelScript>().SetAll(sceneSettings.title,sceneSettings.content,this,sceneMasterScript.GetConditionsState());
    }
    
}
