using UnityEngine;
using System.Collections;

public class FollowPath : State {
    
    private int i;
    public FollowPath(IFSMcontext context)
    {
        this.context = context;
    }

    public override void onUpdate()
    {
        
        float distance = Vector3.Distance(context.enemyPath[i].position, context.enemy.position);
        
        if(distance > 2)
        {
            
            Debug.Log("POR AQUI DEBE DE PASAR!!!");
            context.navAgent.SetDestination(context.enemyPath[i].position);
        }
        else if(i < context.enemyPath.Length - 1 )
        {
            Debug.Log(i);
            /*The increment happens before the operation. BE CAREFUL!!!!*/
            context.navAgent.SetDestination(context.enemyPath[++i].position);
        }
        else
        {
            /*NOT IMPLEMENTED JUST AN IDEA: Random way point position so the enemy route isn't expected
            int r = Random.Range(0,context.enemyPath.Length - 1);
            Debug.Log("Random" + r);*/

            /*The route is restarted. So the enemy start traveling the way-points all over again from the beginning*/
            i = 0;
        }
    }
}
