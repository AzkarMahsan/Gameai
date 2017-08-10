# Game AI Programming

I have developed a 2D football game in Unity3d 5.6.1. I have created a game that is consistent with the normal rules of football (i.e. a game with two opposing teams trying to outscore one another) but limited to two players on each side and a 60 second time limit. There is no user input or involvement in the game itself, it is CPU vs CPU only. The user does, however, have an option to stop, resume, replay, play or exit the game. Each team has one goalkeeper and one outfield player - each player role has individual skill attributes, capabilities and roles. As one would expect, the goalkeeper’s role in each team is to prevent the opposition from scoring. The goalkeeper of both teams are always looking at the ball so if the ball moves left then the goalkeepers focus is left and if the ball moves right then the goalkeepers focus is right. When a goal scoring attempt is made, the ball will travel to the goalkeeper and the goalkeeper will try to catch the ball. If the goalkeeper has successfully caught the ball he will then pass it forward to his team mate.  The outfield player’s role is to win the ball, beat the opponent and score goals. A goal is only successfully registered if the whole ball passes the goal line which is set between the goal posts. Once the outfield player successfully scores a goal the scoreboard is also updated.
When a goal has been scored the position of players, goalkeeper and the position of ball is reset back to their respective starting positions at the start of the game. It is also important to note that the time will not reset. Also, if the ball gets kicked outside the ground then the object positions will also be reset. The game will end when the time limit of 60 seconds has been meet. Basic functions of unity3d were used to develop this game such as Distance, LookAt, OnCollision, MoveToward, Range etc. Basic libraries were used to develop this game. 

No extra libraries have been used in this game, the libraries used in this project are:

•	Using System.Collections ;

•	Using System.Collections.Generic ;

•	Using UnityEngine;

•	Using UnityEngine.UI; 


Below are the main components used in this football game that I will discuss:

•	Plane

•	Ball

•	Goalkeeper

•	Player

•	Time Manager

•	Main Menu Manager

•	Game Manager

Plane:

Plane is basically a 3D object of Unity3d on which I mapped a texture of football ground. This describes the structure of football game. The edges of ground are covered by an invisible sidewall. The purpose of the sidewall is to restrict the ball and players to the boundaries of the ground. If the ball hits or collides with any sidewall then the game object will reset back to their original positions. This is the function that will help us to do this:

    void OnCollisionEnter (Collision collision)
    { 
        if ((collision .collider .tag == "Ball")
        { 
            GameManager .Instance .Reset();
        }
    }  

Objects such as ball and team players will move on this plane. 


Ball:

The ball is a 3D sphere game object, this game will only consist of one ball. At kick off the ball will be placed in the centre of plane. Ball speed will depend on the how the players collides with the ball. At the start of the game the ball will be assign to an outfield player randomly. This is the function that help us assign the ball:

haveballID = Randomv.Range (1, 2); 


When the ball has passed the goal line which is set by the goal posts then the goal has been counted and the score will increase by one. As shown below;

   void OnTriggerEnter ( Collider other)
    {
        if ( other .tag == "Ball")
        {
            score += 1; function
            total = score;
            GameManager .Instance .Reset ();
        }
    }

 
Goalkeeper:

The goalkeeper is a 3D cube game object. The role of goalkeeper in this game is save a goal attempt made by the opposition outfield player. If the keeper then catches the ball then it will pass the ball to there outfield player. As stated above the goalkeepers focus is always on the ball. This line is used for the focus.

Transform .LookAt (GameObject .FindGameObjectWithTag ("Ball") .transform); 


As stated above when the goalkeeper catches the ball the goalkeeper will pass the ball to their outfield player. Below is a line of code that is used to pass the ball to their teammate.

GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody>().AddForce((teamPlayer.transform.position)); 

The Ball will pass to the player based on their collision. If goalkeeper collides with ball then the ball will pass to their team mate.

    void OnCollisionEnter ( Collision collision)
    { 
        if (collision .collider .tag == "Ball")
        { 
            GoalKeeperPass();
        }
    } 


Outfield player:

The outfield player's objective is also developed by using a 3D cube. The difference between the outfield player and goalkeeper is that outfield player can move in the plane anywhere within the limits of the pitch but the goalkeeper is restricted to its certain area. Outfield players also have different properties such as kicking the ball and tackling.

Simple calculations are used for player activities such as when the player kicks the ball. If the distance between the goal posts is less than 3 then the player position will be in-front of the goal posts. Force will be added on the ball when the ball collides with the rigid body.
 
if (( Vector3 .Distance ( this .transform .position, points[9] .transform .position ) <= 3 ) || (Vector3 .Distance (this .transform .position, points[10] .transform .position) <= 3 ) || (Vector3 .Distance (this .transform .position, points[11] .transform .position )) <= 3 )

        {   
            Kick();
            finalpoint = true;
        } 

void Kick()

    {
        Ball .Instance .kicked = true; 
        this .transform .LookAt (GameObject .FindGameObjectWithTag ("Goal Team B") .transform .position);

        GameObject .FindGameObjectWithTag ("Ball") .GetComponent <Rigidbody>() .AddForce ((GameObject .FindGameObjectWithTag ("Goal Team B") .transform .position) * 0.5f);
        finalpoint = false;
    } 

The player can move the ball toward the opposition's goal, random points will be mapped on the runtime for the players movements. So, the player of a particular team that has the ball will follow their path and the opposition player will run alongside this player and attempt to tackle the ball. The player can only move when the player has the ball. Below is the code used for player movement 

GameObject .FindGameObjectWithTag ("Ball") .transform.parent = this .transform;

this .transform .LookAt (points[destination] .transform .position);

float step = Random .Range (1, 3) * Time .deltaTime;

transform .position = Vector3 .MoveTowards (transform .position, points [destination] .transform .position, step );

When the player reaches their destination then a new destination will be created. So now the player will follow the new destination for their movement. The player will then try to attempt to score a goal and the opposition player will then try to tackle the ball. If the player has been successful at the attempt and scores a goal. The players of both the teams will reset back to their original positions as shown below:

    public void Reset()
    {
        PlayerPrefs .SetInt ( "TeamAScore" , GoalTeamA .Instance .total );
        PlayerPrefs .SetInt ("TeamBScore", GoalTeamB .Instance .toatal );
        PlayerPrefs .SetFloat ("Timer", TimeManager .Instance .Timer );

        Application .LoadLevel (Application .loadedLevel );    } 




 Time Manager:


The total game duration is 60 seconds, so the game will be stopped when the time duration is complete. The following function is used for time calculation.

Secs .text = Mathf .Floor( Timer % 60) .ToString("00");
mint = Mathf .Floor (Timer / 60);
sec = Mathf .Floor (Timer % 60);
if ( Timer <= 1)

{ 
GameManager .Instance .StopGame();
}


 Main Menu Manager:

The game will start with a main menu window. This was not a requirement, but is helpful for us to make a user friendly graphic user interface. On the main menu screen there are operational buttons such as exit, play now and sound on/off.

The exit button is used to close the game, when we click on the exit button the game process will be killed. Below is a line of code that is the used for this functionality.

    public void Exit()
    {
        Application .Quit();
    }
    
Sound on\off is used for the background sound. Background sound is only limited for the main menu window. Initially sound will be turned OFF. But when the user clicks on the sound ON button then the sound will start playing. If the user wants to turn the sound OFF then all he/she simply does is click on sound OFF button. Below is a line of code that is used to implement this functionality:

    public void Sound()
    {
        if (soundon.activeInHierarchy)
        {
            AudioListener.volume = 0;
            soundon.SetActive(false);
            soundoff.SetActive(true);

        }
        else
        {
            AudioListener.volume = 1;
            soundon.SetActive(true);
            soundoff.SetActive(false);

        }

    }
    
Another button that is available on the main menu is the play button. The Play button is used to start the game. When we click on the play button the game will start. Below is a line of code that is used to implement this functionality:

    public void Play()
    {
        Application.LoadLevel(Application.loadedLevel + 1);

    }
    
Game Manager:

Game manager is the class that is used to manage the game such as start the of the game, reset the game and pause the game, etc.

Reset the game is the function that will reset the players position after the goal has been scored . Below is a line of code that is used for this implementation: 

    public void Reset()
    {
        PlayerPrefs.SetInt("TeamAScore", GoalTeamA.Instance.total);
        PlayerPrefs.SetInt("TeamBScore", GoalTeamB.Instance.toatal);
        PlayerPrefs.SetFloat("Timer", TimeManager.Instance.Timer);

        Application.LoadLevel(Application.loadedLevel); 
    }
    
The stop game functionality is used to stop the game, below is a line of code that is  used for this purpose:

    public void StopGame()
    { 
        Time.timeScale = 0;
    }

References are in the MmenuManager.cs script: (https://github.com/AzkarMahsan/Gameai/blob/master/Assets/Scripts/MmenuManager.cs)

Youtube link:
https://www.youtube.com/watch?v=9Qzo5ZUZ7nQ








