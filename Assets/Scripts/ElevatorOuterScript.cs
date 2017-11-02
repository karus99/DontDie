using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorOuterScript : MonoBehaviour
{
    public GameObject buttons;

    private void OnMouseDown()
    {
        this.buttons.SetActive(true);
        Destroy(this.gameObject);
    }
}
