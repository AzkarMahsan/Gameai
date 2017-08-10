using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	
	#region variables initialization
    public GameObject GoalKeeperTeamA, PlayerTeamA, GoalKeeperTeamB, PlayerTeamB;
    #endregion

	#region Object initialization
    public static GameManager Instance;

    void Awake()
    {
        Instance = this;
    }

    #endregion

    #region core
    void Start () {
       
        // freeze the Game
        Time.timeScale = 0;

	}
	
   
	// Update is called once per frame.
	void Update () {
		
	}

    #endregion

    #region reset

    // this function is used for reset the game after a goal
    public void Reset()
    {
        // resetting the position of ball and storing the values on a permanent based
        PlayerPrefs.SetInt("TeamAScore", GoalTeamA.Instance.total);
        PlayerPrefs.SetInt("TeamBScore", GoalTeamB.Instance.toatal);
        PlayerPrefs.SetFloat("Timer", TimeManager.Instance.Timer);

        Application.LoadLevel(Application.loadedLevel);
        


    }

    #endregion

    #region Stop Game

    public void StopGame()
    {
        // freeze the game 
        Time.timeScale = 0;

    }

    #endregion

    #region Start Game
    public void StartGame()
    {
        // resuming game
        Time.timeScale = 1;

    }
    #endregion
}
