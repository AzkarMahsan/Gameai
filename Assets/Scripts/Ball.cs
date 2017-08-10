using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	#region variables initialization
    [HideInInspector]
    public int haveballID = 0;
    [HideInInspector]
    public bool kicked = false;
    public GameObject Player1, Player2;


    #endregion

	#region Object initialization
    public static Ball Instance;

    void Awake()
    {

        Instance = this;
    }

   
    #endregion

    #region Core
	// Use this for initialization.
    void Start () {
        // it will randomly generate numbers on which decision will be taken aka which player will have the ball
        haveballID = Random.Range(1, 2);
	}
	
	
    #endregion

    #region collision

    // detecting the collision
    void OnCollisionEnter(Collision collision)
    {
        // checking if collide object is player of team A
        if(collision.collider.tag == "Team A")
        {
            Debug.Log(haveballID);
            haveballID = 1;
           
        }
        else
        {
            // checking if collide object is player of team B
            if (collision.collider.tag == "Team B")
            {
                Debug.Log(haveballID);
                haveballID = 2;
               
            }
        }


    }
        #endregion
    }
