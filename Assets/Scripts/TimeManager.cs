using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{

	#region variables Initialization
    public Text Secs;
    float _Timer;
     static float mint = 0, sec = 0;
    public float Timer
    {
        get { return _Timer; }
        set { _Timer = value; }
    }
    #endregion

    #region object initialization

    public static TimeManager Instance;

    void Awake()
    {
        Instance = this;
    }
    #endregion

    #region core
    void Start () {

       
        // if it is not the first time then the last time will be resumed.
        if (PlayerPrefs.GetFloat("Timer") != 0)
        {
            Timer = PlayerPrefs.GetFloat("Timer");
        }
        // if it is the first time then it will a new game and the timer will be 60 seconds
        else
        {
            Timer = 60;
        }
        mint = 0; sec = 0;
	}
	
	// Update is called once per frame
	void Update () {

        Timer -= Time.deltaTime;
       
      // = Mathf.Floor(timer % 60).ToString("00");

       // calculating the minutes and seconds
        Secs.text = Mathf.Floor(Timer % 60).ToString("00");
        mint = Mathf.Floor(Timer / 60);
        sec = Mathf.Floor(Timer % 60);

        if (Timer <= 1)
        {
            // if timer is 0 then the gameover function will be called
            GameManager.Instance.StopGame();
        }

   


    }
    #endregion

  
}
