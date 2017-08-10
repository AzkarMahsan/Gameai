using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sidewall : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame.
    void Update()
    {
		
    }

    void OnCollisionEnter(Collision collision)
    {
        // checking if thing collides with boundry wall collider
        if ((collision.collider.tag == "Ball") /*|| (collision.collider.tag == "Team A") || (collision.collider.tag == "Team B")*/)
        {
            // if collided object is ball tif it is then game will be reset
            GameManager.Instance.Reset();
        }
    }
}