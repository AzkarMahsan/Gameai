using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// below api for GUI
using UnityEngine.UI;

public class GoalTeamB : MonoBehaviour
{


	#region Variables Initialization
    public Text TeamAScore;
    int score;
    [HideInInspector]
    public int toatal;
    #endregion

	#region Object Initialization
    public static GoalTeamB Instance;

    void Awake()
    {
        Instance = this;
    }
    #endregion

    #region Core Functions
	// Use this for Initialization.
    void Start()
    {
		//initialising the score with 0
        score = PlayerPrefs.GetInt("TeamBScore");
    }

    // Update is called once per frame
    void Update()
    {
        // assigning the GUI score text value of score
        TeamAScore.text = score.ToString();
		// assigning this value to total so that we can write it on hard drive in the Game Manager Reset function
        toatal = score;
    }

    #endregion

    #region Collision

	// checking function weather the ball enters in the pole or not
    void OnTriggerEnter(Collider other)
    {
        // checking if entered object is ball or not
        if (other.tag == "Ball")
        {
			// if entered object is a ball then adds the score
            score += 1;
            toatal = score;
			// assigning this value to total so that we can write it on hard drive in the Game Manager Reset function
            GameManager.Instance.Reset();
        }
    }

    #endregion

}
