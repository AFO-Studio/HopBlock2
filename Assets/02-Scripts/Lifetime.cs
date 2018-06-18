using UnityEngine;

public class Lifetime : MonoBehaviour {

	private void Start ()
    {
        //destroys object after it's off screen
        Destroy(gameObject, 10);
	}

}
