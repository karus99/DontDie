using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGamePanelScript : MonoBehaviour
{
    public Text txt_title;
    public Text txt_content;
    public Button button;
    public LivesShowManager livesManager;
    public AudioClip winSound;
    public AudioClip loseSound;
    public Text txt_playerPoints;
    public Text txt_levelPoints;

    private GameManagerScript gameManager;
    private int levelPoints;
    private int currentlyOverallPoints;
    private int playerPoints;
    // Use this for initialization
    void Start()
    {
    }

    public void SetAll(string title, string content, GameManagerScript gameManager, bool conditionMet, int livesLeft, bool liveLost, int levelPoints,int playerPoints)
    {
        this.gameManager = gameManager;
        currentlyOverallPoints = playerPoints;
        this.levelPoints = levelPoints;
        txt_levelPoints.text = levelPoints+"";
        txt_playerPoints.text = playerPoints+"";
        this.playerPoints = currentlyOverallPoints + levelPoints;

        SetButton(livesLeft, liveLost);
        if (conditionMet)
        {
            txt_title.text = "Nice!";
            txt_content.text = "";
            GetComponent<AudioSource>().clip = winSound;

        }
        else
        {
            txt_title.text = "Oh no!";
            GetComponent<AudioSource>().clip = loseSound;
        }
        txt_content.text = content;

        livesManager.ShowLives(livesLeft);
        GetComponent<AudioSource>().Play();
        StartCoroutine(ShowPoints());
    }
    

    private void SetButton(int livesLeft, bool liveLost)
    {
        if (!liveLost || liveLost && livesLeft > 0)
        {
            button.GetComponentInChildren<Text>().text = "NEXT LEVEL";
            button.onClick.AddListener(delegate { gameManager.LoadNextScene(); });
        }
        else
        {
            button.GetComponentInChildren<Text>().text = "MAIN MENU";
            button.onClick.AddListener(delegate { gameManager.LoadMainMenuScene(); });
        }
    }

    IEnumerator ShowPoints()
    {
        const int pointIncrease = 10;
        while (currentlyOverallPoints < playerPoints)
        {
            currentlyOverallPoints += pointIncrease;
            if (currentlyOverallPoints > playerPoints) {
                currentlyOverallPoints = playerPoints;
            }
            txt_playerPoints.text = currentlyOverallPoints + "";
            yield return new WaitForSeconds(0.03f);
            
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
