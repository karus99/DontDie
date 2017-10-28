using UnityEngine;
using System.Collections;

public class FinishPointScript : MonoBehaviour
{
    SceneMasterScript sceneMaster;
    // Use this for initialization
    void Start()
    {
        sceneMaster = GameObject.FindObjectOfType<SceneMasterScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sceneMaster.SetConditionsSate(true);
        Debug.Log("Enter house");
    }
}
