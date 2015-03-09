using UnityEngine;
using System.Collections;
using Pathfinding;
using System.Collections.Generic;

namespace Pathfinding {
	
	public abstract class Path {
		
		//public PathFinder pathFinder;
		
		
		//private GraphNode[] aPath;
		private Vector3[] aVectorPath;
		
		//public List<GraphNode> path;
		
		public List<Vector3> vectorPath;
		
		public float maxFrameTime;
		
		//protected PathNode current;
		
		public float duration;			
		public int searchIterations = 0;
		public int searchedNodes;		
		
		
		
		
		public float GetTotalLength () {
			if (vectorPath == null) return float.PositiveInfinity;
			float tot = 0;
			for (int i=0;i<vectorPath.Count-1;i++) tot += Vector3.Distance (vectorPath[i],vectorPath[i+1]);
			return tot;
		}
		
	}
}