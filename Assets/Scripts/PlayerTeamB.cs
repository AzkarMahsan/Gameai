using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeamB : MonoBehaviour
{

	#region variables Initialization


    bool move = false, haveball = true;

    public GameObject[] points;
    [HideInInspector]
    public int pointId, destination;
    bool traveling = true, finalpoint = false;
    public GameObject targetPlayer;


    #endregion


    #region core

	// Use this for Initialization.
    void Start()
    {
        move = false;
        this.transform.position = points[7].transform.position;
        destination = Random.Range(3, 8);
    }

    // Update is called once per frame
    void Update()
    {

		// checking if the player is at the points which is infront of the goal, then the player will kick the ball
        if (/*(Vector3.Distance(this.transform.position, points[0].transform.position) <= 3) ||*/ (Vector3.Distance(this.transform.position, points[1].transform.position) <= 3) /*|| (Vector3.Distance(this.transform.position, points[2].transform.position)) <= 3*/)
        {

            finalpoint = true;
            Kick();
        }

		// if the player has the ball then it will move on the points
        if (Ball.Instance.haveballID == 2)
        {

			// if this player has the ball than it makes the ball this player a child
            GameObject.FindGameObjectWithTag("Ball").transform.parent = this.transform;
			// setting the destination and looking at the destination
            this.transform.LookAt(points[destination].transform.position);
            // setting the speed
            float step = Random.Range(1, 3) * Time.deltaTime;
            // moving toward the destination
            transform.position = Vector3.MoveTowards(transform.position, points[destination].transform.position, step);
        }
        else
        {
			// if player doesnt have ball than it will follow the ball to get it aka tackle
            if (Ball.Instance.haveballID == 1)
            {
               
                // looking at the target player mean ball
                this.transform.LookAt(targetPlayer.transform.position);
                // setting the speed
                float step = 0.5f * Time.deltaTime;
                // moving toward the target
                transform.position = Vector3.MoveTowards(transform.position, targetPlayer.transform.position, step);
            }
        }
		// when player reaches the destination point
        if ((Vector3.Distance(this.transform.position, points[destination].transform.position) <= 3) && finalpoint == false)
        {
            UpdateDestination();
        }


    }

    #endregion


    #region kick
    void Kick()
    {
        Ball.Instance.kicked = true;
        // now looking at opponents goal
        this.transform.LookAt(GameObject.FindGameObjectWithTag("Goal Team A").transform.position);
        // pushing the ball by kicking it
        GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody>().AddForce((GameObject.FindGameObjectWithTag("Goal Team A").transform.position) * 0.5f);
        finalpoint = false;


    }

    #endregion

    #region Update Destination
    void UpdateDestination()
    {
        int temp = 0;
        if (destination == 0)
        {
            Kick();
            UpdateDestination();

        }
        else
        if (destination > 0)
        {
            temp = Random.Range(0, destination);
        }
        
        if (temp != destination)
        {

            Debug.Log(temp);
            destination = temp;
        }
        else
        {
            UpdateDestination();
        }
    }
    #endregion

    #region collision
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Team A")
        {
            transform.position = new Vector3(this.transform.position.x + 0.5f, this.transform.position.y, this.transform.position.z);
           if(Ball.Instance.haveballID == 1)
            {
                Ball.Instance.haveballID = 2;
            }
            else
            {
                Ball.Instance.haveballID = 1;
            }
        }
    }
    #endregion
}