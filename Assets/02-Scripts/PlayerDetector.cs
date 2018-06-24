using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour {

    GameObject levelAssembler;
    PrebuiltLevel preBuiltLevel; 


	// Use this for initialization
	void Start ()
    {
        levelAssembler = GameObject.FindGameObjectWithTag("LevelAssembler");
        preBuiltLevel = levelAssembler.GetComponent<PrebuiltLevel>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            preBuiltLevel.Build();
        }
    }
}
