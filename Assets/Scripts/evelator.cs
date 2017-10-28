using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evelator : MonoBehaviour {
    bool buttonClick=false;

    private void OnMouseDown()
    {
        if (!buttonClick)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(0.99f, 1.00f, 0.05f);
            buttonClick = true;
            Shake shake = GameObject.FindObjectOfType<Shake>();
            shake.timesButton--;
        }

    }
}


