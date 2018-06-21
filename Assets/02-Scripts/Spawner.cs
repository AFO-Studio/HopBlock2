using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject platform; //pulls in the desired platform object

    //minimum and maximum sizes the platform can be
    private float PlatSizeMin; 
    private float PlatSizeMax;

    //boundaries that define where on the screen space the platform can spawn
    //private float MaxHeightBound;
    //private float MinHeightBound;

	private void Start ()
    {
        //starts the coroutine
        StartCoroutine(interval());
	}

    IEnumerator interval()
    {
        while (true)
        {
            Spawning();

            //will wait a desired number of seconds
            yield return new WaitForSeconds(1);
        }
    }

    //spawns a new platform object
    private void Spawning()
    {
        float height = Random.Range(-3f, 3f);

        //instantiates new platform object
        GameObject newPlatform = Instantiate(platform, new Vector2(transform.position.x-6, transform.position.y+height), Quaternion.identity);

        //seeds random value once to create uniform scale Vec2 in line below
        float scale = Random.Range(1.1f, 1.9f);

        //changes the scale of the platform
        newPlatform.transform.localScale = new Vector2(scale, scale);
    }

}
