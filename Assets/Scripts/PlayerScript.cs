using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    Rigidbody2D rigidbody2d;
	// Use this for initialization
	void Start () {
        rigidbody2d = this.GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {
       // rigidbody2d.velocity = new Vector2(0, 0.1f);

    }
    private void FixedUpdate()
    {
        
    }

    public void voidAddForceLeft() {
        rigidbody2d.AddForce(new Vector2(100, 0));
    }
}
