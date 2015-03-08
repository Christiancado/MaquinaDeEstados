using UnityEngine;
using System.Collections;

public class Ear : MonoBehaviour {


    bool blocked;
    [SerializeField]
    private FiniteStateMachine fsm;


    void OnTriggerStay(Collider coll)
    {

        if (coll.tag == fsm.player.tag)
        {
            /*I use two conditionals so I don't have to throw the ray-cast if it isn't needed*/
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
                fsm.LastPointSeen();
            }
        }
    }
}
