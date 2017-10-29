using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlinkElementScript : MonoBehaviour
{
    private float currColor = 1.0f;
    private bool dir = true;

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
            currColor += 0.04f;

            if (currColor >= 1.0f)
            {
                dir = !dir;
                currColor = 1.0f;
            }
        }
        else
        {
            currColor -= 0.04f;

            if (currColor <= 0.5f)
            {
                dir = !dir;
                currColor = 0.7f;
            }
        }
        sRenderer.color = new Color(currColor, currColor, currColor);
    }
}
