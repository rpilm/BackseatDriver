//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using Pathfinding;
//
//namespace Pathfinding {
//	
//	public class ABPath : Path {
//		
//		public bool recalcStartEndCosts = true;
//		
//		public GraphNode startNode; 
//		public GraphNode endNode;   
//		
//		public Vector3 originalStartPoint;
//		public Vector3 originalEndPoint;
//		
//		public Vector3 startPoint;
//		public Vector3 endPoint;
//		
//		public bool hasEndPoint = true;
//		public Int3 startIntPoint; 
//		
//		public bool calculatePartial = false;
//		
//		protected PathNode partialBestTarget = null;
//		protected int[] endNodeCosts;
//		
//		public ABPath (Vector3 start, Vector3 end, OnPathDelegate callbackDelegate) {
//			Reset ();
//			Setup (start, end, callbackDelegate);
//		}
//		
//		
//		public ABPath () {}
//		
//		public static ABPath Construct (Vector3 start, Vector3 end, OnPathDelegate callback = null) {
//			ABPath p = PathPool<ABPath>.GetPath ();
//			p.Setup (start, end, callback);
//			return p;
//		}
//		
//		protected void Setup (Vector3 start, Vector3 end, OnPathDelegate callbackDelegate) {
//			callback = callbackDelegate;
//			UpdateStartEnd (start,end);
//		}		
//		
//		protected void UpdateStartEnd (Vector3 start, Vector3 end) {
//			originalStartPoint = start;
//			originalEndPoint = end;
//			
//			startPoint = start;
//			endPoint = end;
//			
//			startIntPoint = (Int3)start;
//			hTarget = (Int3)end;
//		}
//		
//		public override uint GetCost (GraphNode a, GraphNode b, uint currentCost) {
//			if (startNode != null && endNode != null) {
//				
//				if (a == startNode) {
//					return (uint)((startIntPoint - (b == endNode ? hTarget : b.position)).costMagnitude * (currentCost*1.0/(a.position-b.position).costMagnitude));
//				} else if (b == startNode) {
//					return (uint)((startIntPoint - (a == endNode ? hTarget : a.position)).costMagnitude * (currentCost*1.0/(a.position-b.position).costMagnitude));
//				} else if (a == endNode) {
//					return (uint)((hTarget - b.position).costMagnitude * (currentCost*1.0/(a.position-b.position).costMagnitude));
//				} else if (b == endNode) {
//					return (uint)((hTarget - a.position).costMagnitude * (currentCost*1.0/(a.position-b.position).costMagnitude));
//				}
//			} else {
//				if (a == startNode) {
//					return (uint)((startIntPoint - b.position).costMagnitude * (currentCost*1.0/(a.position-b.position).costMagnitude));
//				} else if (b == startNode) {
//					return (uint)((startIntPoint - a.position).costMagnitude * (currentCost*1.0/(a.position-b.position).costMagnitude));
//				}
//			}
//			
//			return currentCost;
//		}
//		
//		public override void Reset () {
//			base.Reset ();
//			
//			startNode = null;
//			endNode = null;
//			startHint = null;
//			endHint = null;
//			originalStartPoint = Vector3.zero;
//			originalEndPoint = Vector3.zero;
//			startPoint = Vector3.zero;
//			endPoint = Vector3.zero;
//			calculatePartial = false;
//			partialBestTarget = null;
//			hasEndPoint = true;
//			startIntPoint = new Int3();
//			hTarget = new Int3();
//			
//			endNodeCosts = null;
//		}
//		
//		
//		
//		public override void Initialize () {
//			
//			
//			if (startNode != null) Path.GetPathNode (startNode).flag2 = true;
//			if (endNode != null) Path.GetPathNode (endNode).flag2 = true;
//			
//			if (hasEndPoint && startNode == endNode) {
//				PathNode endNodeR = pathHandler.GetPathNode (endNode);
//				return;
//			}
//			
//		}
//		
//		public void CalculateStep (long targetTick) {
//			
//			int counter = 0;
//			
//			while (CompleteState == Path.NotCalculated) {
//				searchedNodes++;
//				if (currentR.node == endNode) {
//					CompleteState = Path.Complete;
//					break;
//				}
//				
//				if (currentR.H < partialBestTarget.H) {
//					partialBestTarget = currentR;
//				}
//				
//				if (counter > 500) {
//					return;
//				}
//				counter = 0;
//			}
//			
//			counter++;
//		}
//		
//		
//		
//	}
//	public Vector3 GetMovementVector (Vector3 point) {
//		
//		if (vectorPath == null || vectorPath.Count == 0) {
//			return Vector3.zero;
//		}
//		
//		if (vectorPath.Count == 1) {
//			return vectorPath[0]-point;
//		}
//		
//		float minDist = float.PositiveInfinity;
//		int minSegment = 0;
//		
//		for (int i=0;i<vectorPath.Count-1;i++) {
//			
//			
//			float dist = (closest-point).sqrMagnitude;
//			if (dist < minDist) {
//				minDist = dist;
//				minSegment = i;
//			}
//		}
//		
//		return vectorPath[minSegment+1]-point;
//	}
//	
//}
//}