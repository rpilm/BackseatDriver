using UnityEngine;
using System.Collections;

public class Pathfinder : MonoBehaviour {

	public GameObject intersectionGroup; 
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void GetPath (Transform startingPosition, Transform EndPosition) {
		Debug.Log ("Getting path from" + startingPosition.position + " to " + EndPosition.position);
	
		Debug.Log ("I don't know.  Ask google maps");
	}
	
	
	public Transform GetRandomDestination ()
	{
		// get a random child of the intersection group and return its transform
		
		int n = intersectionGroup.transform.childCount;
		
		int i = Random.Range (0,n);
		
		// get the transform
		
		Transform t = intersectionGroup.transform.GetChild(i);
		
		return t;
	
	}
	
	
}
