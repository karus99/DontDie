using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGamePanelScript : MonoBehaviour
{
   public Text txt_title;
   public Text txt_content;
   public Button btn_repeatLevel;
   public Button btn_mainMenu;
   public Button btn_nextLevel;
   public LivesShowManager livesManager; 


    // Use this for initialization
    void Start()
    {
    }

    public void SetAll(string title, string content, GameManagerScript gameManager,bool conditionMet,int  livesLeft, bool liveLost) {
        if (conditionMet)
        {
            txt_title.text = "Nice! You know how to react in case of ";
            txt_content.text = "";
            btn_repeatLevel.gameObject.SetActive(false);
        }
        else {
            txt_title.text = "Oh! You dont know what to do in case of ";
        }
        txt_content.text = content;
        txt_title.text += title+".";

        livesManager.ShowLives(livesLeft);

        btn_repeatLevel.onClick.AddListener(delegate { gameManager.RepeatScene(); });
        btn_mainMenu.onClick.AddListener(delegate { gameManager.LoadMainMenuScene(); });
        btn_nextLevel.onClick.AddListener(delegate { gameManager.LoadNextScene(); });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
