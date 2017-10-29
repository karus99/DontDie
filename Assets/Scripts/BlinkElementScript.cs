using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlinkElementScript : MonoBehaviour
{
    private float currColor = 1.0f;
    private bool dir = true;
    private float colorStep=0.02f;

    private SpriteRenderer sRenderer;
    // Use this for initialization
    void Start()
    {
        sRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!dir)
        {
            currColor += colorStep;

            if (currColor >= 1.0f)
            {
                dir = !dir;
                currColor = 1.0f;
            }
        }
        else
        {
            currColor -= colorStep;

            if (currColor <= 0.5f)
            {
                dir = !dir;
                currColor = 0.5f;
            }
        }
        sRenderer.color = new Color(currColor, currColor, currColor);
    }
}
