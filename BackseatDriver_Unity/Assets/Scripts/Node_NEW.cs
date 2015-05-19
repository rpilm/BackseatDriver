using UnityEngine;
using System.Collections;

public class Node_NEW : MonoBehaviour {
	public GameObject[] neighbors;
	Pathfinder_NEW player;
	
	void OnTriggerEnter(Collider c)	{
		//as the player enters a node, simply update their "current" node to be this one and call the getNextNode() function to assign the next target node.
		if (c.gameObject.name == "Player") {
			player.current_node = this.gameObject;
			player.next_node = getNextNode();

			//no need to tell the player which way to turn on a corner since it's effectively one-way
			if(this.gameObject.name != "corner")	{
				player.tellNextDirection();
			}
		}
	}


	Vector3 correct_direction;
	Vector3 player_direction;


	void OnTriggerExit(Collider c)	{
		//as the player exits a node, check that they are going the "right" direction by getting the dot product of their direction and the direction they "should" be going.
		//for reference, the dot product of two vectors going in the same direction = 1, while in the opposite direction = 0. For this, the dot must be > 0.8
		if (c.gameObject.name == "Player") {
			correct_direction = player.next_node.transform.position - player.current_node.transform.position;
			correct_direction.Normalize();
			player_direction = player.gameObject.transform.forward;
			player_direction.Normalize();
			float dot = Vector3.Dot(correct_direction, player_direction);

			//because corners are effectively one direction, they should not be reacted to
			if(this.gameObject.name != "corner")	{
				if(dot > 0.8f)	{
					Debug.Log ("WOO YOU MADE THE CORRECT TURN!");
				}
				else {
					Debug.Log ("****WRONG TURN****");
				}
			}

		}
	}

	//"finds" the next node to go for based off which neighbor is closest to the final destination (aka target)
	public GameObject getNextNode()	{
		float closest_dist = 100000f;
		//just giving the first neighbor at first for the sake of initialization
		GameObject pref_node = neighbors [0];

		for (int n = 0; n < neighbors.Length; n++) {
			//the next node should NOT be the node that the player just came from (in case of player trying to U-turn or anything else)
			//dir = 0 = up (positive on z axis)
			//dir = 1 = right (positive on x axis)
			//dir = 2 = down (negative on z axis)
			//dir = 3 = left (negative on x axis)
			if(player.dir == 0 && neighbors[n].transform.position.z < this.gameObject.transform.position.z)	{
				continue;
			}
			else if(player.dir == 1 && neighbors[n].transform.position.x < this.gameObject.transform.position.x)	{
				continue;
			}
			else if(player.dir == 2 && neighbors[n].transform.position.z > this.gameObject.transform.position.z)	{
				continue;
			}
			else if(player.dir == 3 && neighbors[n].transform.position.x > this.gameObject.transform.position.x)	{
				continue;
			}
			else {
				//find the neighbor node that is closest to the "target" (final destination)
				float current_dist = Vector3.Distance(player.target.transform.position, neighbors[n].transform.position);
				if(current_dist < closest_dist)	{
					pref_node = neighbors[n];
					closest_dist = current_dist;
				}
			}
		}
		return pref_node;
	}

	void Start()	{
		player = GameObject.Find ("Player").GetComponent<Pathfinder_NEW> ();
	}

	// Update is called once per frame
	void Update () {

	}
}
