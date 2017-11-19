using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LivesShowManager : MonoBehaviour
{ 
    public Image[] lives = new Image[3];

    public Sprite liveLost;

    // Use this for initialization
    void Start()
    {
        //liveLost = Resources.Load<Sprite>("Graphics/Heart/heart_17");
    }

    // Update is called once per frame
    void Update()
    {

    }

    //TODO: change to creating images during runtime not creating and disabling
    public void ShowLives(int count)
    {
        switch (count)
        {
            case 0:
                if(count == 0)
                {
                    lives[0].GetComponent<Animator>().SetBool("isDestroying", true);
                }
                else
                {
                    Destroy(lives[0].GetComponent<Animator>());
                    lives[0].sprite = liveLost;
                }
                goto case 1;
            case 1:
                if (count == 1)
                {
                    lives[1].GetComponent<Animator>().SetBool("isDestroying", true);
                }
                else
                {
                    Destroy(lives[1].GetComponent<Animator>());
                    lives[1].sprite = liveLost;
                }
                goto case 2;
            case 2:
                if (count == 2)
                {
                    lives[2].GetComponent<Animator>().SetBool("isDestroying", true);
                }
                else
                {
                    Destroy(lives[2].GetComponent<Animator>());
                    lives[2].sprite = liveLost;
                }
                break;
        }
             
    }
}
