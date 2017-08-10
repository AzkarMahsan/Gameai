using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//references 
//https://docs.unity3d.com/ScriptReference/Rigidbody.AddForce.html
//https://unity3d.com/learn/tutorials/topics/physics/adding-physics-forces
//https://gamedevelopment.tutsplus.com/tutorials/understanding-steering-behaviors-collision-avoidance--gamedev-7777
//https://msdn.microsoft.com/en-gb/magazine/dn759441.aspx
//https://unity3d.com/learn/tutorials/topics/user-interface-ui/creating-main-menu
//https://unity3d.com/learn/tutorials/topics/2d-game-creation/2d-game-development-walkthrough
//https://unity3d.com/learn/tutorials
//https://www.youtube.com/watch?v=yQXdREL4GGg
//https://unity3d.com/learn/tutorials/projects/roll-ball-tutorial/displaying-score-and-text


public class MmenuManager : MonoBehaviour {

	#region variables Initialization

    public GameObject soundon, soundoff;

    #endregion

    #region core

	// Use this for Initialization
    void Start () {

        PlayerPrefs.SetFloat("Timer", 60f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    #endregion

    #region Play

    public void Play()
    {
        // in this line we are loading the game play scene aka next scene
        Application.LoadLevel(Application.loadedLevel + 1);

    }

    #endregion

    #region Sound

    // in this function we enabling and disabling the sound
    public void Sound()
    {
        // we are checking that if the sound on button is active
        if (soundon.activeInHierarchy)
        {
            //  we are putting off the sound and enabling sound off button by disabling sound on button
            AudioListener.volume = 0;
            soundon.SetActive(false);
            soundoff.SetActive(true);

        }
        else
        {
            // we are putting on the sound and enabling sound off button by disabling it and enabling sound on button
            AudioListener.volume = 1;
            soundon.SetActive(true);
            soundoff.SetActive(false);

        }

    }

    #endregion

    #region exit
    public void Exit()
    {
        // quits the application.
        Application.Quit();

    }

    #endregion
}
