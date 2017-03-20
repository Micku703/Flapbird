using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
   
    public Animator scoreanim;

    // Use this for initialization
    void Start ()
    {
       scoreanim = GetComponent<Animator>();
	scoreanim.SetBool("Blue", false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit2D(Collider2D other)  // trigger score function ever time the bird exits the 2D collider 
	{
        if (other.tag == "Add Point")
        {
            GameManager.score++; //adds 1 to the current score value 
            Debug.Log("New score: " + GameManager.score); //calls the score variable of gamemanager script 
            scoreanim.SetBool("Blue", true);
        }
    }

}
