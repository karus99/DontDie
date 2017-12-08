using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    int lives =3;
    public GameObject prefabTimeBar;

    // Buttons
    public GameObject prefabMainMenuPanel;

    public GameObject sceneMaster;

    private float originalTimeToEnd = 0.0f;
    private float timeToEnd = 0.0f;
    private float timeOnLevelEnd;
    private RawImage timeBar;
    private bool gameStarted = false;
    SceneMasterScript sceneMasterScript;

    public GameObject endGamePanelPrefab;
    private GameObject endGamePanel;
    public GameObject pauseGamePanelPrefab;
    private GameObject pauseGamePanel;
    public GameObject pauseGameButtonPrefab;
    public Button pauseGameButton;

    private bool gamePaused=false;
    //Player
    int playerPoints;

    private void Awake()
    {
        pauseGameButton = Instantiate(pauseGameButtonPrefab, GameObject.FindObjectOfType<Canvas>().GetComponent<Transform>()).GetComponent<Button>();
        pauseGameButton.onClick.AddListener(delegate { PauseGame(true); });
    }

    // Use this for initialization
    void Start ()
    {
        sceneMasterScript = sceneMaster.GetComponent<SceneMasterScript>();

        LoadMainMenuScene();
        
    }
	
	// Update is called once per frame

	void Update ()
    {
	    if(timeBar!=null && timeToEnd > 0.0f && gameStarted)
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
        int pointsForLevel = 0;
        bool liveLost;
        sceneMasterScript.UnloadScene();
        if(sceneMasterScript.GetConditionsState())
        {
            Debug.Log("Conditions were met");
            liveLost = false;
            pointsForLevel = CalculateLevelPoints();
            playerPoints += pointsForLevel;
        }
        else
        {
            lives--;
            liveLost = true;
            Debug.Log("Conditions were not met");
        }
        ShowEndGamePanel(lives,liveLost,pointsForLevel);
        if (timeBar != null)
        {
            Destroy(timeBar.transform.parent.gameObject);
        }
        // things to do.
    }

    private int CalculateLevelPoints() {
        SceneSettingsScript sceeneSettings= sceneMasterScript.GetSceneSettingsScript();
        int points = 0; ;

        if (sceeneSettings.pointsCountingType.Equals(PointsCountingType.Time))
        {
            float pointsForSecond = 50;
            points = (int)Mathf.Round(timeOnLevelEnd * pointsForSecond / 5.0f) * 5;
        }
        else if(sceeneSettings.pointsCountingType.Equals(PointsCountingType.Finish)){
            points = sceeneSettings.pointsForLevel;
        }
        return points;
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

    public void StartGame() {
        playerPoints = 0;
        lives = 3;
        LoadNextScene();
        pauseGameButton.gameObject.SetActive(true);
    }

    public void LoadNextScene() {
        pauseGameButton.gameObject.SetActive(true);
        sceneMasterScript.LoadNextRandomScene();
        SetTimeToEnd(sceneMasterScript.sceneTime);
        AddTimeBar();
        if (endGamePanel != null) Destroy(endGamePanel);
    }
    public void RepeatScene() {
        pauseGameButton.gameObject.SetActive(true);
        sceneMasterScript.RepeatScene();
        SetTimeToEnd(sceneMasterScript.sceneTime);
        AddTimeBar();
        if (endGamePanel != null) Destroy(endGamePanel);
    }

    public void LoadMainMenuScene()
    {

        if (timeBar != null)
        {
            Destroy(timeBar.transform.parent.gameObject);
        }
        sceneMasterScript.UnloadScene();
        pauseGameButton.gameObject.SetActive(false);
        Instantiate(prefabMainMenuPanel, GameObject.FindObjectOfType<Canvas>().GetComponent<Transform>());
        sceneMasterScript.LoadMainMenuScene();
        if (endGamePanel != null) Destroy(endGamePanel);
    }

    public void ShowEndGamePanel(int lives, bool liveLost, int pointsForLevel)
    {
        pauseGameButton.gameObject.SetActive(false);
        if (endGamePanel != null) Destroy(endGamePanel);
        Transform parent = GameObject.FindObjectOfType<Canvas>().transform;
        endGamePanel = Instantiate(endGamePanelPrefab, parent);
        SceneSettingsScript sceneSettings = sceneMasterScript.GetSceneSettingsScript();
        endGamePanel.GetComponent<EndGamePanelScript>().SetAll(sceneSettings.title,sceneSettings.content,this,sceneMasterScript.GetConditionsState(),lives,liveLost, pointsForLevel,playerPoints-pointsForLevel);
    }

    public void FinishGameScene() {
        timeOnLevelEnd = timeToEnd;
        timeToEnd = 0.1f;
    }

    public void PauseGame(bool value) {
        gamePaused = value;
        if (gamePaused)
        {
            pauseGamePanel = Instantiate(pauseGamePanelPrefab, GameObject.FindObjectOfType<Canvas>().GetComponent<Transform>());
            pauseGameButton.gameObject.SetActive(false);
            Time.timeScale = 0;
        }
        else {
            pauseGameButton.gameObject.SetActive(true);
            if (pauseGamePanel != null) Destroy(pauseGamePanel);
            Time.timeScale = 1;
        }
    }

}
