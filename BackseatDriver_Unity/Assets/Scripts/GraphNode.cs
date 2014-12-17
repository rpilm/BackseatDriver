using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using Pathfinding.Nodes;
using Pathfinding.Serialization;


namespace Pathfinding {
	

	public abstract class GraphNode {
		
		private int nodeIndex;
		protected int flags;
		private int penalty;

		public GraphNode (APath astar) {

			if (astar != null) {
				this.nodeIndex = astar.GetNewNodeIndex();
				astar.InitializeNode (this);
			} else {
				throw new System.Exception ("No active AstarPath object to bind to");
			}
		}

		public int NodeIndex { get {return nodeIndex;}}
		
		public Int3 position;
		

		public uint Flags {
			get {
				return flags;
			}
			set {
				flags = value;
			}
		}
		public abstract void GetConnections (GraphNodeDelegate del);
		
		public abstract void AddConnection (GraphNode node, uint cost);
		public abstract void RemoveConnection (GraphNode node);

	}
	
}