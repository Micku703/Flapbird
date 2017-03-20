using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnBehaviour : MonoBehaviour {

	Rigidbody2D col_rb; //calls the rgidbody of column object 
	float range;

	// Use this for initialization
	void Start () {
		range = 2.4f; //the range of the columns 
		col_rb = GetComponent<Rigidbody2D> ();
		col_rb.velocity = new Vector2 (-3,0);

        
        
        //moves the column prefab to random position within specifid range 
        Vector2 newPos;  
		newPos = transform.position;
		newPos.y = Random.Range (-range, range);
		col_rb.MovePosition (newPos); 


	}
	
	// Update is called once per frame
	void Update () {


		Vector2 col_pos = Camera.main.WorldToScreenPoint (transform.position); //refers to the edge of the screen
		if (col_pos.x < 0f) {  

			Destroy (gameObject,1f); //destroys column after reaching edge
		}


	}
}
