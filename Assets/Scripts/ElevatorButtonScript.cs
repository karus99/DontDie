using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButtonScript : MonoBehaviour
{
    public EarthquakeElevatorScript sceneController;
    private void OnMouseDown()
    {
        this.GetComponent<SpriteRenderer>().color = new Color(0.99f, 1.00f, 0.05f);
        sceneController.buttonsLeft--;
        Destroy(this);
    }
}
