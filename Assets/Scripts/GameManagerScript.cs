using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public GameObject prefabTimeBar;
    public GameObject sceneMaster;

    private float originalTimeToEnd = 0.0f;
    private float timeToEnd = 0.0f;
    private RawImage timeBar;
    private bool gameStarted = false;
    SceneMasterScript sceneMasterScript;

    public GameObject endGamePanelPrefab;
    private GameObject endGamePanel;

    // Use this for initialization
    void Start ()
    {
        sceneMasterScript = sceneMaster.GetComponent<SceneMasterScript>();

        sceneMasterScript.LoadScene(0);
        SetTimeToEnd(sceneMasterScript.sceneTime);

        if(sceneMasterScript.isGameScene)
        {
            GameObject _timeBar = Instantiate(prefabTimeBar, GameObject.FindObjectOfType<Canvas>().GetComponent<Transform>());
            timeBar = _timeBar.transform.GetChild(0).GetComponent<RawImage>();

            gameStarted = true;
        }
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

    public void LoadNextScene() {
        sceneMasterScript.LoadNextRandomScene();
    }
    public void RepeatScene() {
        sceneMasterScript.RepeatScene();
    }
    public void LoadMainMenuScene() {
        sceneMasterScript.LoadMainMenuScene();
    }

    public void ShowEndGamePanel()
    {
        Transform parent = GameObject.FindObjectOfType<Canvas>().transform;
        endGamePanel = Instantiate(endGamePanelPrefab, parent);
        SceneSettingsScript sceneSettings = sceneMasterScript.GetSceneSettingsScript();
        endGamePanel.GetComponent<EndGamePanelScript>().SetAll(sceneSettings.title,sceneSettings.content);
    }

}
