using UnityEngine;

public class Mover : MonoBehaviour {
    private Rigidbody2D obj;
    public float objectSpeed = 1; //the speed at which the object goes

    public enum Direction //directional enumerator
    {
        Left,
        Right
    };

    public Direction direction = Direction.Left;

    private void Start()
    {
        obj = gameObject.GetComponent<Rigidbody2D>();
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
        if (direction == Direction.Left)
        {
            if (objectSpeed > 0)
            {
                objectSpeed = objectSpeed * -1;
            }
        }
        //if its negative, but we need it to go right this will handle that
        else if (direction == Direction.Right)
        {
            if (objectSpeed < 0)
            {
                objectSpeed = objectSpeed * -1;
            }
        }

        //will add the speed to the object being moved
        obj.velocity = new Vector2(objectSpeed, obj.velocity.y);
    }

}
