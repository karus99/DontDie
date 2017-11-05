﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoRunPlayerScript : MonoBehaviour
{
    Rigidbody2D thisRigidbody2d;
    Animator thisAnimator;

    // int moveForce = 20; unused?
    float maxVelocity = 6;
    float velocityAdd = 1.5f;
    float velocityStep = 0.12f;

    // Use this for initialization
    void Start ()
    {
        thisRigidbody2d = this.GetComponent<Rigidbody2D>();
        thisAnimator = this.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (thisRigidbody2d.velocity.x > 0)
        {
            thisAnimator.SetBool("isWalking", true);
        }
        else
        {
            thisAnimator.SetBool("isWalking", false);
        }
       // rigidbody2d.velocity = new Vector2(0, 0.1f);
    }

    private void FixedUpdate()
    {
        if (thisRigidbody2d.velocity.x > 0)
        {
            float newVelocityX = thisRigidbody2d.velocity.x - velocityStep;
            if (newVelocityX < 0) newVelocityX = 0;
            thisRigidbody2d.velocity = new Vector2(newVelocityX, 0);
        }
    }

    public void MoveLeft()
    {
        float newVelocityX = thisRigidbody2d.velocity.x + velocityAdd;
        if (newVelocityX > maxVelocity) newVelocityX = maxVelocity;
        thisRigidbody2d.velocity = new Vector2(newVelocityX, 0);
    }
}