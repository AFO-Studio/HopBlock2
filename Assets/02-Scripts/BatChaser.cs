using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatChaser : MonoBehaviour {

    public GameObject BatPosition;


    // Update is called once per frame
    private void FixedUpdate()
    {
       gameObject.transform.position = new Vector3(gameObject.transform.position.x, Mathf.Lerp(gameObject.transform.position.y, BatPosition.transform.position.y, 3.0f * Time.deltaTime), gameObject.transform.position.z);
    }

}
