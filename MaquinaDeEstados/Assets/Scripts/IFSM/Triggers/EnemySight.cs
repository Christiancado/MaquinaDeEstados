using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour {

    bool blocked;
    [SerializeField]
    private FiniteStateMachine fsm;


    void OnTriggerStay(Collider coll)
    {
        /*With NavMeshHit is an easier and a fancier way of doing a ray-cast in a controlled environment*/

        /* A little documentation about it in case you want to see it working: This function follows the path of a 
         * "ray" between the agent's position and the specified target position. If an obstruction is encountered 
         * along the line then a true value is returned and the position and other details of the obstructing 
         * object are stored in the hit parameter.*/
    

       

       
        if (coll.tag == fsm.player.tag )
        {
            /*I use two conditionals so I don't have to throw the raycast if it isn't needed*/
            NavMeshHit hit;
            blocked = fsm.navAgent.Raycast(fsm.player.position, out hit);
            Debug.DrawLine(fsm.enemy.position, fsm.player.position, blocked ? Color.red : Color.green);
            if (!blocked)
            {
                /*We prepare the boolean "playerLastPosition" to make sure that it will react correctly in the State ChaseToLastPointSeen*/
                fsm.playerLastPosition = true;

                fsm.ChasingAndAttacking();
            }
          
        }
        else if (coll.tag == fsm.player.tag)
        {
            Debug.Log("LAST POINT SEEN?????????");
            fsm.LastPointSeen();
        }
    }

    void OnTriggerExit(Collider coll)
    {

        if (coll.tag == fsm.player.tag)
        {
            NavMeshHit hit;
            blocked = fsm.navAgent.Raycast(fsm.player.position, out hit);
            Debug.DrawLine(fsm.enemy.position, fsm.player.position, blocked ? Color.red : Color.green);
            if (!blocked)
            {

                Debug.Log("ITS ENTERING ON TRIGGER EXIT");

                fsm.LastPointSeen();
            }
        }
        }
    }

