// this script is for Goal Keeper
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalKeeperTeamA : MonoBehaviour
{

	#region variables initialization

    bool follow;
    public GameObject teamPlayer;
    bool triger = false;

    #endregion

	#region object initialization
    public static GoalKeeperTeamA Instance;

    void Awake()
    {
        Instance = this;
    }
    #endregion

    #region Core

	// Use this for initialization.
    void Start()
    {
        follow = true;

    }

    // Update is called once per frame
    void Update()
    {
       
            transform.LookAt(GameObject.FindGameObjectWithTag("Ball").transform);
           
}

    #endregion

    #region Pass Function
    void GoalKeeperPass()
    {
        //pushing the ball
        follow = false;
        triger = false;
        // pushing the ball toward the team player
        GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody>().AddForce((teamPlayer.transform.position));


    }

    #endregion

    #region collision
    //checking the collide object
    void OnCollisionEnter(Collision collision)
    {
        // checking that colide object is ball or not
        if (collision.collider.tag == "Ball")
        {
            // if it is ball than pasing it to player
            GoalKeeperPass();
        }
    }
    #endregion
}
