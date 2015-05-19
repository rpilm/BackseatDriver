BACKSEAT DRIVER PATHFINDING
Karl Olsen



***********WHAT I DID*****************
-Re-made roadmap (NewCity.unity scene) and consolidated/renamed street sections for the sake of a much neater project.
-Implemented Node system for each intersection.
-Implemented Node-based pathfinding/instruction/reaction "AI".
-Cleaned up several outstanding car control bugs.

******************GENERAL NOTES************************
-Due to the street tiles given being very inconsistent in terms of position, the tellNextDirection() function in Pathfinder_NEW.cs
checks to see if neighbor node positions are outside of a tolerance level to find direction, otherwise it would be preferable to just see
if "next_node.transform.position.x > current_node.transform.position.x" or vice versa.
-The neighbors of each node are "hardcoded" in through the inspector so if you make a new map or alter the current one, make sure to change
the neighbors accordingly. The order does not affect the algorithm.


*******INSTRUCTIONS FOR IMPLEMENTING SOUNDS FOR INSTRUCTION/REACTION**********
Once the proper sound file is in the Unity project, just throw in the calls for the sounds in the Pathfinder_NEW.cs file
under the functions "public void tellNextDirection()". There are already Debug.log messages in the function saying "TURN RIGHT",
"TURN LEFT", and "STRAIGHT", either replace them with the calls for the appropriate sounds or just throw in the calls above/below
the debug messages if you want to keep them in.

As for the passenger reacting to the player turning, under the Node_NEW.cs file, there is the OnTriggerExit function. Implementation
of the reaction sounds is the same as the instructions, just throw in the appropriate calls for the reaction sound files where there is
"WOO YOU MADE THE CORRECT TURN!" and "****WRONG TURN****".



********KNOWN BUGS/REMAINING ISSUES**************
-Upon reaching the 4way intersection closest to the target (at least in the map I currently use), an IndexOutOfRangeException() error
occurs, though it does not actually affect/stop the game. The error does not make sense though, as it claims that that intersection(node)
does not have a neighbors[0] item, when you can see that it actually does in the inspector.

-When it comes to arriving at the final destination from the "last" node, I do not have an implementation set up, but there are 2 solid options:
--Just make the final destinations be at a node themselves and consider the assignment "completed" upon reaching that last node.
--Have some form of big red arrow or other symbol pointing down at the ground for the player to see.
---Main reason for this option is that because the pathfinding system is node-based, setting a destination to some open space and giving the 
proper instruction becomes much trickier.

-While I fixed the general throttle/acceleration issues with the car, it could potentially use some tweaking on the anti-slip variable, but that
largely comes down to the preference of the professors.
