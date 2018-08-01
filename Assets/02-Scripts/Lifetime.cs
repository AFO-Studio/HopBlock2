using UnityEngine;

public class Lifetime : MonoBehaviour {

    public int time = 15;

	private void Start ()
    {
        //destroys object after it's off screen
        Destroy(gameObject, time);

	}

}
