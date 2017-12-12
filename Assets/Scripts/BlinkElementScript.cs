using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlinkElementScript : MonoBehaviour
{
    public Color targetColor = new Color(1.0f, 1.0f, 1.0f);
    public int steps = 50;

    private Color colorStep;

    private Color baseColor;
    private Color currColor;
    private bool dir = true;

    private SpriteRenderer sRenderer;
    // Use this for initialization
    void Start()
    {
        sRenderer = this.GetComponent<SpriteRenderer>();
        baseColor = currColor = sRenderer.color;
        Color colorDiff = baseColor - targetColor;
        colorStep = colorDiff / steps;
    }

    // Update is called once per frame
    void Update()
    {
        if(!dir)
        {
            currColor += colorStep;

            if (currColor.r >= baseColor.r && currColor.g >= baseColor.g && currColor.b >= baseColor.b)
            {
                dir = !dir;
                currColor = baseColor;
            }
        }
        else
        {
            currColor -= colorStep;

            if (currColor.r <= targetColor.r && currColor.g <= targetColor.g && currColor.b <= targetColor.b)
            {
                dir = !dir;
                currColor = targetColor;
            }
        }
        Debug.Log(currColor.ToString() + " " + baseColor.ToString() + " " + targetColor.ToString());
        sRenderer.color = currColor;
    }
}
