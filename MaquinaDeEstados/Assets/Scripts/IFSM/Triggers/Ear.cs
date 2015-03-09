using UnityEngine;
using System.Collections;

public class Ear : MonoBehaviour {


    bool blocked;
    [SerializeField]
    private FiniteStateMachine fsm;

    /*In ear's case I only use the collider.tag so in concept the enemy can always hear the player in another room*/
    void OnTriggerStay(Collider coll)
    {

        if (coll.tag == fsm.player.tag)
        {
                /*We prepare the boolean "playerLastPosition" to make sure that it will react correctly in the State ChaseToLastPointSeen*/
                fsm.playerLastPosition = true;
                fsm.ChasingAndAttacking();

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
           
                fsm.LastPointSeen();
        }
    }
}
