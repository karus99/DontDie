using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteElevator : MonoBehaviour {

    public GameObject buttons;

    private void OnMouseDown()
    {
        this.gameObject.SetActive(false);
        this.buttons.SetActive(true);
    }

}
