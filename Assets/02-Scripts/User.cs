using UnityEngine;

public class User : MonoBehaviour
{
    private void Start()
    {

    }
    /*private Rigidbody2D player;
    public float jumpHeight = 1; //basically the jump speed/height

	public float limit = 0.3f;//How much the player can jump
	private float toLimit;

    private void Start ()
    {
		toLimit = 0;
		player = gameObject.GetComponent<Rigidbody2D>();
    }
	
	private void Update ()
    {
		//Debug.Log ("toLimit: " + toLimit);
		//Debug.Log (limit);
        //receives input from the touch and checks if you're on the ground
		if (Input.GetKey(KeyCode.Mouse0) && (toLimit < limit)) { //needs secondary condition to make sure that the player in on the ground when we jump
			//adds force to player object
			player.AddForce (new Vector2 (0, jumpHeight), ForceMode2D.Impulse);
			toLimit += Time.deltaTime * 3;
			if (toLimit > (limit * 0.85))	//When it gets near limit, push it way over so that it now has to cool down.
				toLimit *= 2;
				
		} 
		else if (Input.GetKeyUp(KeyCode.Mouse0) && (toLimit < limit))	//if the player releases the mouse after jumping, toLimit goes way up
			toLimit *= 2.8f;	
		else
			if (toLimit  > 0)
				toLimit -= Time.deltaTime;	//cooldown
	}
}*/

    public float lowestVelocity = 4f;   //lowest possible jump velocity
    public float highestVelocity = 8f;          //highest possible jump velocity

    bool jump = false;
    bool jumpCancel = false;
    bool grounded = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && grounded)   //start pressing the buttons
            jump = true;
        if (Input.GetMouseButtonUp(0) && !grounded)  //stop pressing the buttons
            jumpCancel = true;
        /*if (Input.GetMouseButtonDown(0) && !grounded )  //speeds you downwards
        {
            if(gameObject.GetComponent<Rigidbody2D>().velocity.y > 0)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, (gameObject.GetComponent<Rigidbody2D>().velocity.y + 2.0f) * -1f);
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, gameObject.GetComponent<Rigidbody2D>().velocity.y - 2f);
            }
        }*/

    }

    void FixedUpdate()
    {
        //normal jump 
        if (jump)
        {
            grounded = false;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, highestVelocity);
            jump = false;
        }
        //cancels jump when key is no longer pressed
        if (jumpCancel)
        {
            if (gameObject.GetComponent<Rigidbody2D>().velocity.y > lowestVelocity)
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, lowestVelocity);
            jumpCancel = false;
        }




    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

}
