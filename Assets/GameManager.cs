using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    //variables to insert prefabs and objects and change values
	public GameObject columns;
	public float repeatingTime;
	public static float score;
	public Text scoretext;

	// Use this for initialization
	void Start () {
        //invokes the GenerateColumns function created below 
		score = 0;
		InvokeRepeating ("GenerateColumns", 2f, repeatingTime); // generates every two seconds 
	}
	
	// Update is called once per frame
	void Update () {

		scoretext.text = "Score : " + score;
	}


    //generates columns prefab at the position of column prefab specified in column behavior script
	void GenerateColumns()
	{
		
		Instantiate (columns, transform.position, Quaternion.identity);
	}

}
