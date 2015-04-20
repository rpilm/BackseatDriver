using UnityEngine;
using System.Collections;

public class Node_NEW : MonoBehaviour {
	public int num_neighbors;
	public GameObject neighbors;

	void OnTriggerEnter(Collider c)	{
		if (c.gameObject.name == "Player") {
			return;

		}
		return;
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
	
	// Update is called once per frame
	void Update () {
	
	}
}
