using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour {


	public float force; //gives ability to chnage force value within editor 
	Vector2 upforce;
	Animator birdAnim;
	public Animator UIanimator;

    //states can be called based on "if statements"
	enum BirdState{STARTING,PLAYING,DEAD //states are named

	}

	BirdState state;

	Vector2 birdpos;
	Rigidbody2D bird_rb;
	// Use this for initialization
	void Start () { 

		state = BirdState.STARTING;
		bird_rb = GetComponent<Rigidbody2D> (); //calls rigidbody component of bird
		upforce = new Vector2 (0f, force);
		birdAnim = GetComponent<Animator> ();


	}
	
	// Update is called once per frame
	void Update () {


		switch (state) {

		case BirdState.STARTING:
			Time.timeScale = 0f; //used to pause the game



			break;


		case BirdState.PLAYING:
			
            //below adds upward force to bird everytime space or moused are pressed
			UIanimator.SetBool ("isPlaying", true);
			birdAnim.SetFloat ("VelocityY", bird_rb.velocity.y);
			if (Input.GetMouseButtonDown (0)  ||   Input.GetKeyDown(KeyCode.Space)) {

				bird_rb.velocity = new Vector2 (0, 0);
				bird_rb.AddForce (upforce);


			}

			birdpos = Camera.main.WorldToScreenPoint (transform.position); //defines position of birdpos in relation to the screen
                
                
                //tells the game to end when bird goes beyond bottom of screen or top
                if (birdpos.y > Screen.height || birdpos.y < 0) {  

				Die ();
				state = BirdState.DEAD;
			}
			break;


		case BirdState.DEAD:

			birdAnim.SetBool ("isBirdDead", true); //calls animation when bird is in DEAD state
			UIanimator.SetBool ("isDead", true); //this is the UI animator's bool

			if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown(0)) {

				SceneManager.LoadScene (0);

			}


			break;

		}

	}



    //below defines what happens when bird collides with columns 
	void OnCollisionEnter2D(Collision2D other)
	{

		Die ();

	}


	void Die()
	{
		//do anything to show gameover
		Debug.Log ("Bird dies");
		state = BirdState.DEAD;
	}

    //the below function unpauses the game and puts it in the PLAYING state 
	public void StartGame()
	{
		Time.timeScale = 1f; 
		state = BirdState.PLAYING;
		bird_rb.velocity = new Vector2 (0, 0);
		bird_rb.AddForce (upforce);
	}
    




}
