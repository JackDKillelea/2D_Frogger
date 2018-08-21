using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Player player;
    public Text scoreText;
    public Text levelText;


    private float highestPos;
    private int score = 0;
    private int level = 1;

    // Use this for initialization
    void Start () {
        player.OnPlayerMoved += OnPlayerMoved;
        player.OnPlayerCompleted += OnPlayerCompleted;

        highestPos = player.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnPlayerMoved()
    {
        if (player.transform.position.y > highestPos)
        {
            highestPos = player.transform.position.y;
            score++;
            scoreText.text = "Score: " + score;
        }

        //Debug.Log("Moved");
    }

    void OnPlayerCompleted()
    {
        highestPos = player.transform.position.y;
        level++;
        levelText.text = "Level: " + level;
        //Debug.Log("Completed");
    }
}
