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

    public void SetAll(string title, string content) {
        txt_title.text = title;
        txt_content.text = content;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
