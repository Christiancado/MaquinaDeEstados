using UnityEngine;
using System.Collections;

/*You have to follow an order to add a state to the enemy AI
  1- You put the name of the state class here after the comma.
  2- You create the state class inheriting from State abstract class and implement it's methods.
  3- */
public enum AIstate {
    ChasingAndAttaking,
    FollowPath,
    ChaseToLastPointSeen
}
