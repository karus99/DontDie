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


    // Use this for initialization
    void Start()
    {

    }

    public void SetAll(string title, string content, GameManagerScript gameManager,bool conditionMet) {
        if (conditionMet)
        {
            txt_title.text = "Nice! You did well on ";
            txt_content.text = "";
            btn_repeatLevel.gameObject.SetActive(false);
        }
        else {
            txt_title.text = "You died on ";
            txt_content.text = content;
        }
        txt_title.text += title+".";
        
        btn_repeatLevel.onClick.AddListener(delegate { gameManager.RepeatScene(); });
        btn_mainMenu.onClick.AddListener(delegate { gameManager.LoadMainMenuScene(); });
        btn_nextLevel.onClick.AddListener(delegate { gameManager.LoadNextScene(); });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
