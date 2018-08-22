using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Player player;
    public Text scoreText;
    public Text levelText;
    public Text gameOverText;
    public float difLevel = 1.2f;

    private float highestPos;
    private int score = 0;
    private int level = 1;
    private float restartTimer = 2f;

    // Use this for initialization
    void Start () {
        gameOverText.gameObject.SetActive(false);
        player.OnPlayerMoved += OnPlayerMoved;
        player.OnPlayerCompleted += OnPlayerCompleted;

        highestPos = player.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if(player == null)
        {
            gameOverText.gameObject.SetActive(true);

            restartTimer -= Time.deltaTime;
            if(restartTimer <= 0f)
            {
                SceneManager.LoadScene("Game");
            }
        }
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

        foreach (Enemy enemy in GetComponentsInChildren<Enemy>())
        {
            enemy.speed *= difLevel;
        }
        //Debug.Log("Completed");
    }
}
