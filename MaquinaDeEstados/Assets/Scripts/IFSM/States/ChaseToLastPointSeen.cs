using UnityEngine;
using System.Collections;

public class ChaseToLastPointSeen : State {

   
    Vector3 playerPositionOnTriggerExit;
    float x, y, z;

    public ChaseToLastPointSeen(IFSMcontext context)
    {
        this.context = context;
    }

    public override void onUpdate()
    {

        //Debug.Log(context.navAgent.destination.x +" "+ context.navAgent.destination.y +" "+ context.navAgent.destination.z);
        if(context.playerLastPosition)
        {
            
            playerPositionOnTriggerExit = context.player.position;
            context.navAgent.SetDestination(playerPositionOnTriggerExit);
            context.playerLastPosition = false;
        }
        else if(context.navAgent.destination == playerPositionOnTriggerExit){}
        {
           context.FollowPath();
        }
        
    }
}
