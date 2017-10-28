using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManagerTemplateScript : MonoBehaviour {

    public GameObject sceneMaster;

	// Use this for initialization
	void Start () {

        sceneMaster = GameObject.FindGameObjectWithTag("SceneMaster");
        sceneMaster.GetComponent<SceneMasterScript>().SetConditionsSate(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
