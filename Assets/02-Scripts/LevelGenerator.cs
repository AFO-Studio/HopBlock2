using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class LevelGenerator : MonoBehaviour
{


    public enum directions { up, down, level, random };
    public GameObject GroundTile;
    public Transform generationPoint;
    public float distanceBetween;
    public float heightBetween;
    public directions direction = directions.level;


    private float platformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;
    public float heightBetweenMin;
    public float heightBetweenMax;
    public GameObject killBox;

    public ObjectPooler theObjectPool;

    private void Start()
    {
        platformWidth = GroundTile.GetComponent<BoxCollider2D>().size.x;
        killBox = GameObject.FindGameObjectWithTag("KillBox");
        Debug.Log(killBox.tag);
    }

    // Use this for initialization
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {

            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            heightBetween = Random.Range(heightBetweenMin, heightBetweenMax);

            /*
             * this section controls the height. 
             * First is level, no modification to height. 
             */
            if (direction == directions.level)
            {
                transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween,
                transform.position.y,
                transform.position.z);
                killBox.GetComponent<SmoothFollow>().heightAdjuster(transform.position.y);
            }

            //moves height upwards.
            else if (direction == directions.up)
            {
                transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween,
                transform.position.y + heightBetween,
                transform.position.z);
                killBox.GetComponent<SmoothFollow>().heightAdjuster(transform.position.y + heightBetween);
            }

            //moves height downwards. Strange bug where the platform runs from you after a short period of time. 
            else if (direction == directions.down)
            {
                transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween,
                transform.position.y - heightBetween,
                transform.position.z);
                killBox.GetComponent<SmoothFollow>().heightAdjuster(transform.position.y - heightBetween);
            }

            //randomly selects if the platform will be hiegher or lower than the last one. 
            else if (direction == directions.random)
            {
                if (randomBool())
                {
                    transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween,
                    transform.position.y + heightBetween,
                    transform.position.z);
                    killBox.GetComponent<SmoothFollow>().heightAdjuster(transform.position.y + heightBetween);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween,
                    transform.position.y - heightBetween,
                    transform.position.z);
                    killBox.GetComponent<SmoothFollow>().heightAdjuster(transform.position.y - heightBetween);
                }

            }

            GameObject newPlatform = theObjectPool.GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

        }
    }

    public bool randomBool()
    {
        if (Random.value >= .5f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Regenerate()
    {
        Instantiate(GroundTile, new Vector2(Random.Range(-2, 1), Random.Range(0, 1)), gameObject.transform.rotation);
    }
}