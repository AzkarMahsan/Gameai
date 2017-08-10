using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour {



	#region variables Initialization

    public GameObject pausebtn, resumebtn;

    #endregion

	#region object Initialization

    // declaring the class object static so this can be accessed across the class
    public static GUIManager Instance;

    void Awake()
    {
        // assigning the class reference to object
        Instance = this;
    }

    #endregion

    #region core

	// Use this for Initialization.
    void Start () {

        // this line is used to stop the game play, every thing will freeze using this line
        Time.timeScale = 0;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    #endregion

    #region play

    public void Play()
    {
        // starting the game
        GameManager.Instance.StartGame();

    }

    #endregion

    #region Restart

    public void Restart()
    {
        // deletes all values on hard drive
        PlayerPrefs.DeleteAll();
        // in this line we are reloading the current level
        Application.LoadLevel(Application.loadedLevel);

    }

    #endregion

    #region Pause
    public void Pause()
    {

        // in this if we are checking that if pause button is active then we have to pause the game, as the pause button is pressed
        if (pausebtn.activeInHierarchy)
        {
            // in these lines we are freezing the game and deactivating the pause button and activating the resume button
            Time.timeScale = 0;
            resumebtn.SetActive(true);
            pausebtn.SetActive(false);
        }
        else
        {
            // in these lines we are resuming the game and activing the pause button and deactivating the resume button
            Time.timeScale = 1;
            resumebtn.SetActive(false);
            pausebtn.SetActive(true);
        }
    }

    #endregion

    #region exit

    public void Exit()
    {
        // in this line we are loading the main menu scene
        Application.LoadLevel(Application.loadedLevel - 1);

    }

    #endregion
}
