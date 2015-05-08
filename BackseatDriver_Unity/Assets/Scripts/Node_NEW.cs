using UnityEngine;
using System.Collections;

public class Node_NEW : MonoBehaviour {
	public GameObject[] neighbors;
	Pathfinder_NEW player;
	
	void OnTriggerEnter(Collider c)	{
		if (c.gameObject.name == "Player") {
			player.current_node = this.gameObject;
			player.next_node = getNextNode();
		}
	}
	
	void OnTriggerExit(Collider c)	{
		if (c.gameObject.name == "Player") {
			//****************************************************
			//NEED TO CHANGE THE FIRST ARGUMENT TO THE TARGET_NODE
			//****************************************************
			float dot = Vector3.Dot(this.gameObject.transform.rotation.eulerAngles, c.gameObject.transform.rotation.eulerAngles);
			if(dot > 0.8f)	{
				Debug.Log ("WOO YOU MADE THE CORRECT TURN!");
			}
			else {
				Debug.Log ("Learn how to drive");
			}
		}
	}

	//"finds" the next node to go for based off which neighbor is closest to the final destination (aka target)
	public GameObject getNextNode()	{
		float closest_dist = 100000f;
		//just giving the first neighbor at first for the sake of initialization
		GameObject pref_node = neighbors [0];
		for (int n = 0; n < neighbors.Length; n++) {
			float current_dist = Vector3.Distance(player.target.transform.position, neighbors[n].transform.position);
			if(current_dist < closest_dist)	{
				pref_node = neighbors[n];
				closest_dist = current_dist;
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
