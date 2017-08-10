using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// below api for GUI
using UnityEngine.UI;

public class GoalTeamA : MonoBehaviour {


	#region Variables initialization
    public Text TeamAScore;
    int score;
    [HideInInspector]
    public int total;
    #endregion

	#region Object initialization
    public static GoalTeamA Instance;

    void Awake()
    {
        Instance = this;
    }
    #endregion

    #region Core Functions
	// Use this for initialization.
    void Start () {
		//initialising the score with 0
        score = PlayerPrefs.GetInt("TeamAScore");
	}
	
	// Update is called once per frame.
	void Update () {
        // assigning the GUI score text value of score
        TeamAScore.text = score.ToString();
        // assigning this value to total so that we can write it on hard drive in the Game Manager Reset function
        total = score;
	}

    #endregion

    #region Collision

    // checking function weather the ball enters in the pole or not
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("in function");
        // checking if entered object is ball or not
        if (other.tag == "Ball")
        {
            Debug.Log("in if");
            // if entered object is a ball then adds the score
            score += 1;
            // assigning this value to total so that we can write it on hard drive in the Game Manager Reset function
            total = score;
            GameManager.Instance.Reset();
        }
    }
    #endregion

}
