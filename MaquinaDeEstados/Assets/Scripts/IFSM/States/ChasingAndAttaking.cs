using UnityEngine;
using System.Collections;
using System.Timers;


public class ChasingAndAttaking: State {
    GameObject bullet;
    bool shooting = true;
    Animation anim;

  
    public ChasingAndAttaking(IFSMcontext context)
    {
        this.context = context;
        anim = context.enemy.gameObject.GetComponent<Animation>();
    }

    public override void onUpdate()
    {
        float distance = Vector3.Distance(context.player.position, context.enemy.position);
        if(distance > 4 && distance < 20)
        {
            /*I stop the previous animation and then play once one that leave the gameobject in it's original position*/
            anim.Stop();
            anim.Play("StayStill");
            context.navAgent.SetDestination(context.player.position);

            if(shooting)
            {

                Timer aTimer = new Timer(500);
                aTimer.Elapsed += onTimerFinish;
                aTimer.AutoReset = false;
                aTimer.Start();

                shooting = false;

                bullet = GameObject.Instantiate(context.bulletPrefab) as GameObject;
                bullet.transform.position = context.gun.transform.position;
                /*!!!The Speed should be serialized in the context*/
                bullet.rigidbody.velocity = context.gun.transform.forward */*SPEED*/ 50;
                /*The bullet gameobject is destroyed after one second THE PREFAB HAS IT´S OWN SCRIPT*/
            }
          
        }
        else if(distance <= 3)
        {
            
            //HERE THE CLOSE COMBAT CODE AND OR ANIMATION
           
            context.navAgent.stoppingDistance = 3;
            anim.Play("CloseAttackComplete");
            
        }
        else
        {
            
            anim.Stop();
            anim.Play("StayStill");
            context.navAgent.SetDestination(context.player.position);
        }
        
        
    }
    void onTimerFinish(System.Object source, ElapsedEventArgs e)
    {
       
        shooting = true;
    }
}


