﻿using UnityEngine;
using System.Collections;

public class Pathfinder_NEW : MonoBehaviour {
	public GameObject current_node;
	Node_NEW current;
	public GameObject next_node;
	public GameObject target;

	//direction tracking variable
	//Beacuse y axis is irrelevant:
	//0 = "up" (positive z)
	//1 = "right" (positive x)
	//2 = "down" (negative z)
	//3 = "left" (negative x)
	public int dir;
	float tolerance = 80f;

	// Use this for initialization
	void Start () {
		current = current_node.GetComponent<Node_NEW> ();
	}

	public void tellNextDirection()	{
		//if player arrives at the intersection moving up
		if (dir == 0) {
			if(next_node.transform.position.z - current_node.transform.position.z > tolerance)	{
				//tell the player to go straight
				Debug.Log("STRAIGHT");
			}
			else if(next_node.transform.position.x - current_node.transform.position.x > tolerance)	{
				//tell the player to go right
				Debug.Log("TURN RIGHT");
			}
			else if(next_node.transform.position.x - current_node.transform.position.x < -tolerance)	{
				//tell the player to go left
				Debug.Log("TURN LEFT");
			}
		}
		//if player arrives at the intersection moving right
		else if (dir == 1) {
			if(next_node.transform.position.z - current_node.transform.position.z > tolerance)	{
				//tell the player to go left
				Debug.Log("TURN LEFT");
			}
			else if(next_node.transform.position.z - current_node.transform.position.z < -tolerance)	{
				//tell the player to go right
				Debug.Log("TURN RIGHT");
			}
			else if(next_node.transform.position.x - current_node.transform.position.x > tolerance)	{
				//tell the player to go straight
				Debug.Log("STRAIGHT");
			}
		}
		//if player arrives at the intersection moving down  
		else if (dir == 2) {
			if(next_node.transform.position.z - current_node.transform.position.z < -tolerance)	{
				//tell the player to go straight
				Debug.Log (next_node.transform.position.z - current_node.transform.position.z);
				Debug.Log("STRAIGHT");
			}
			else if(next_node.transform.position.x - current_node.transform.position.x < -tolerance)	{
				//tell the player to go right
				Debug.Log("TURN RIGHT");
			}
			else if(next_node.transform.position.x - current_node.transform.position.x > tolerance)	{
				//tell the player to go left
				Debug.Log("TURN LEFT");
			}
		}
		//if player arrives at the intersection moving left
		else {
			if(next_node.transform.position.z - current_node.transform.position.z < -tolerance)	{
				//tell the player to go left
				Debug.Log("TURN LEFT");
			}
			else if(next_node.transform.position.z - current_node.transform.position.z > tolerance)	{
				//tell the player to go right
				Debug.Log("TURN RIGHT");
			}
			else if(next_node.transform.position.x - current_node.transform.position.x < -tolerance)	{
				//tell the player to go straight
				Debug.Log("STRAIGHT");
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.transform.rotation.eulerAngles.y > 315 || this.gameObject.transform.rotation.eulerAngles.y < 45)
			dir = 0;
		else if (this.gameObject.transform.rotation.eulerAngles.y > 45 && this.gameObject.transform.rotation.eulerAngles.y < 135)
			dir = 1;
		else if (this.gameObject.transform.rotation.eulerAngles.y > 135 && this.gameObject.transform.rotation.eulerAngles.y < 225)
			dir = 2;
		else if (this.gameObject.transform.rotation.eulerAngles.y > 225 && this.gameObject.transform.rotation.eulerAngles.y < 315)
			dir = 3;
	}
}
