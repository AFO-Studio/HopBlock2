using UnityEngine;

public class Mover : MonoBehaviour {
    private Rigidbody2D obj;
    public float objectSpeed = 0.4f; //the speed at which the object goes

    public enum Direction //directional enumerator
    {
        Left,
        Right
    };

    public Direction direction = Direction.Left;

    private void Start()
    {
        obj = gameObject.GetComponent<Rigidbody2D>();
       // if (direction == Direction.Right)
           
    }

    private void Update()
    {
       //This is not the way to do it.  It must be static per player, not per platform. objectSpeed += objectSpeed * Time.deltaTime * 0.2f;    //Accelerate the platforms
    }

    private void FixedUpdate()
    {
        Moving(); //call to moving function
    }

    //set object speed
    public void SetSpeed(float speed)
    {
        objectSpeed = speed;
    }

    public void Moving()
    {
        //if its positive, but we need it to go left this will handle that
        if (direction == Direction.Right)
        {
            if (objectSpeed < 0)
            {
                objectSpeed = objectSpeed * -1;
            }
        }
        //if its negative, but we need it to go right this will handle that
        else if (direction == Direction.Left)
        {
            if (objectSpeed > 0)
            {
                objectSpeed = objectSpeed * -1;
            }
        }

        //will add the speed to the object being moved
        obj.velocity = new Vector2(objectSpeed, obj.velocity.y);
    }

}
