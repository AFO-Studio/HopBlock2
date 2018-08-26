using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour {

    public float killPosition;

	void Update ()
    {
		if(transform.position.y < killPosition - 20)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
	}

    public void SetKillPosition(float _KillPosition)
    {
        killPosition = _KillPosition;
    }
}
