using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrebuiltLevel : MonoBehaviour {

    public List<GameObject> selection;
    public bool useRareSelection = true;
    [Range(1,10)]
    public float rarity = 9;
    public List<GameObject> rareSelection;
    public float speed = 1f;
    public bool rightToLeft;

    private List<GameObject> built = new List<GameObject>();

	// Use this for initialization
	void Start ()
    {
        Build();
        SpeedAdjuster(12);
	}
	

    public void Build()
    {
        Vector3 NextSpawnPoint = transform.position;
        
        if (built.Count <= 0)
        {
 
            built.Add(Instantiate(SelectPlatform(), transform.position, Quaternion.identity));
            built[built.Count - 1].GetComponent<Mover>().SetSpeed(speed);

            NextSpawnPoint = built[built.Count - 1].transform.Find("SpawnPoint").transform.position;

            built.Add(Instantiate(SelectPlatform(), NextSpawnPoint, Quaternion.identity));
            built[built.Count - 1].GetComponent<Mover>().SetSpeed(speed);
            //built[built.Count - 1].GetComponent<PlayerDetector>().preBuiltLevel = gameObject.GetComponent<PrebuiltLevel>();
            if (rightToLeft)    //Reverse direction for Right-to-left platforms
                built[built.Count - 1].GetComponent<Mover>().direction = Mover.Direction.Right;

        }

        //if there are already platforms, build another one on the last childs spawnpoint. 
        else 
        {
            NextSpawnPoint = built[built.Count - 1].transform.Find("SpawnPoint").transform.position;
            built.Add(Instantiate(SelectPlatform(), NextSpawnPoint, Quaternion.identity));
            built[built.Count - 1].GetComponent<Mover>().SetSpeed(speed);
        }
    }

    GameObject SelectPlatform()
    {
        if(Random.Range(1f, 10f) >= rarity && useRareSelection == true && rareSelection.Count > 0)
        {
            return rareSelection[Random.Range(0, rareSelection.Count)];
        }
        else
        {
            return selection[Random.Range(0, selection.Count)];
        }
    }

    public void SpeedAdjuster(float speed)
    {
        foreach(GameObject platformGroup in built)
        {
            platformGroup.GetComponent<Mover>().SetSpeed(speed);
        }
        this.speed = speed;
    }

}
