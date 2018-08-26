using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GOD : MonoBehaviour {
    public GameObject player1LevelAssembler;
    public GameObject player2LevelAssembler;
    public Camera player1Camera;
    public Camera player2Camera;
    public GameObject player1;
    public GameObject player2;
    public int score = 0;
    public Text scoreText;

    private MusicManager musicManager;

    public bool twoPlayer = false;
    //load in score object
    //score addition over time
    //collect item for money


        //on start here I'll have to set it to look at what scene it is to figure if it should be playing whatever song.
    private void Start()
    {
        if (twoPlayer == false)
        {
            player1Camera.GetComponent<Camera>().rect = new Rect(player1Camera.rect.x, player1Camera.rect.y, player1Camera.rect.width, 1.0f);
            player1Camera.GetComponent<Camera>().orthographicSize = 4;
            Destroy(player2Camera);
            Destroy(player2LevelAssembler);
        }
        else
        {
            player1Camera.GetComponent<Camera>().rect = new Rect(player1Camera.rect.x, player1Camera.rect.y, player1Camera.rect.width, .5f);
            Matrix4x4 mat = player2Camera.projectionMatrix;
            mat *= Matrix4x4.Scale(new Vector3(-1, -1, 1));
            player2Camera.projectionMatrix = mat;
        }
        musicManager = MusicManager.instance;

        if(musicManager == null)
        {
            Debug.Log("There is no music manager here.");
        }
        else
        {
            if(SceneManager.GetActiveScene().name == "Main")
            {
                musicManager.PlaySound("GamePlayLoop", true);
            }
            if (SceneManager.GetActiveScene().name == "HopBlock_MainMenu")
            {
                musicManager.PlaySound("MenuMusic", true);
            }
        }

        StartCoroutine("ScoreIncrement");
    }

    IEnumerator ScoreIncrement()
    {
        while(true)
        {
            score++;
            scoreText.text = "Score: " + score.ToString();
            yield return new WaitForSeconds(1);
        }
    }

    private void FixedUpdate()
    {
        player1Camera.transform.position = new Vector3(player1Camera.transform.position.x, Mathf.Lerp(player1Camera.transform.position.y, player1.transform.position.y, 5.0f * Time.deltaTime), player1Camera.transform.position.z);
    }
}
