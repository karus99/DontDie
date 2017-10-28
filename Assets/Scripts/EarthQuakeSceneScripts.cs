using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthQuakeSceneScripts : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GameObject sceneMaster = GameObject.FindGameObjectWithTag("SceneMaster");
        sceneMaster.GetComponent<SceneMasterScript>().SetConditionsState(true);
    }
	

}
