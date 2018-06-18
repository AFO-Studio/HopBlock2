using UnityEngine;

public class User : MonoBehaviour {
    private Rigidbody2D player;
    private float jumpHeight = 10; //basically the jump speed/height

    private void Start ()
    {
		player = gameObject.GetComponent<Rigidbody2D>();
    }
	
	private void FixedUpdate ()
    {
        //receives input from the touch and checks if you're on the ground
        if (Input.GetKeyDown(KeyCode.Mouse0)) //needs secondary condition to make sure that the player in on the ground when we jump
        {
            //adds force to player object
            player.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }
	}
}
