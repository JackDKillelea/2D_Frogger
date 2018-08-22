using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public delegate void PlayerHandler();
    public event PlayerHandler OnPlayerMoved;
    public event PlayerHandler OnPlayerCompleted;

    public float jumpDist = 0.32f;

    private bool moving = false;
    private Vector3 startingPos;

	// Use this for initialization
	void Start () {
        //Debug.Log(Screen.width);
        //Debug.Log(Screen.height);

        startingPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        // Movement logic.
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        if(!moving)
        {
            Vector2 targetPos = Vector2.zero;
            bool tryingToMove = false;

            //  The wizard didn't move.
            if (horizontalMovement != 0)
            {
                tryingToMove = true;
                targetPos = new Vector2(
                    transform.position.x + (horizontalMovement > 0 ? jumpDist : -jumpDist),
                    transform.position.y);
            }
            if(verticalMovement != 0)
            {
                tryingToMove = true;
                targetPos = new Vector2(
                    transform.position.x,
                    transform.position.y + (verticalMovement > 0 ? jumpDist : -jumpDist)
                    );
            }

            // Test for collision between the wizard and other parts of the game scene.
            Collider2D hitCollider = Physics2D.OverlapCircle(targetPos, 0.1f);
            if(tryingToMove == true && (hitCollider == null || hitCollider.GetComponent<Enemy>() != null))
            {
                transform.position = targetPos;
                moving = true;
                GetComponent<AudioSource>().Play();

                if (OnPlayerMoved != null)
                {
                    OnPlayerMoved();
                }
            }

        }
        else    
        {
            // The wizard did move.
            if (horizontalMovement == 0 && verticalMovement == 00)
            {
                moving = false;
            }
        }


        // Keep wizard inside the window.
        //Debug.Log(-(Screen.height) / 100 / 2);
        if(transform.position.y < -((float)Screen.height) / 100 / 2)
        {
            // Checking for the lower bound in the Y axis.
            transform.position = new Vector3(transform.position.x, transform.position.y + jumpDist);
        }

        if (transform.position.y > ((float)Screen.height) / 100 / 2)
        {
            // Checking for the upper bound in the Y axis.
            transform.position = startingPos;
            if(OnPlayerCompleted != null)
            {
                OnPlayerCompleted();
            }
        }


        if (transform.position.x < -((float)Screen.width) / 100 / 2)
        {
            // Checking for the left bound in the X axis.
            transform.position = new Vector3(transform.position.x + jumpDist, transform.position.y);
        }

        if (transform.position.x > ((float)Screen.width) / 100 / 2)
        {
            // Checking for the right bound in the X axis.
            transform.position = new Vector3(transform.position.x - jumpDist, transform.position.y);
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if(otherCollider.GetComponent<Enemy>() != null)
        {
            Destroy(gameObject);
        }
    }
}
