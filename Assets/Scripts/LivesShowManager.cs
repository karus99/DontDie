using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LivesShowManager : MonoBehaviour
{
    public Image live1;
    public Image live2;
    public Image live3;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    //TODO: change to creating images during runtime not creating and disabling
    public void ShowLives(int count) {
        switch (count) {
            case 0:
                live1.gameObject.SetActive(false);
                goto case 1;
            case 1:
                live2.gameObject.SetActive(false);
                goto case 2;
            case 2:
                live3.gameObject.SetActive(false);
                break;
        }
             
    }
}
