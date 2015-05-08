using UnityEngine;
using System.Collections;

public class Pathfinder_NEW : MonoBehaviour {
	public GameObject current_node;
	Node_NEW current;
	public GameObject next_node;
	public GameObject target;

	// Use this for initialization
	void Start () {
		current = current_node.GetComponent<Node_NEW> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
