using UnityEngine;
using System.Collections;

public class GoodElementClickedScript : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameObject sceneMaster = GameObject.FindGameObjectWithTag("SceneMaster");
        sceneMaster.GetComponent<SceneMasterScript>().SetConditionsState(true);
        GameManagerScript gameManager = GameObject.FindObjectOfType<GameManagerScript>();
        gameManager.FinishGameScene();
    }
}
