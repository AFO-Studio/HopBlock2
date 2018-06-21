using System.Collections;
using UnityEngine;

public class ObjectEffect : MonoBehaviour {
    
    //time coroutine
    IEnumerator interval()
    {
        //the choice of effect evaluates a specific action
        switch (choice)
        {
            case Effect.Phasing:
                while (true)
                {
                    Phasing();

                    //will wait a desired number of seconds
                    yield return new WaitForSeconds(3);
                }
            default:
                Debug.Log("there is no effect");
                break;
        }   
    }

    //the enum that defines the choice of effect
    public enum Effect 
    {
        Phasing,
        ColorGradient,
    };

    //the choice of effect
    public Effect choice;

    private void Update ()
    {
        //calls interval
        interval();
	}

    //will make the object phase
    private void Phasing ()
    { 
        if (gameObject.GetComponent<SpriteRenderer>().enabled == true)
        {
            //hides the object
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            //shows the object
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }  
    }
}
