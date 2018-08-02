using UnityEngine;

public class Lifetime : MonoBehaviour {

    public int time = 15;

    private void Start()
    {
        //Destroys after a set time. 
        Destroy(gameObject, time);
    }
}
