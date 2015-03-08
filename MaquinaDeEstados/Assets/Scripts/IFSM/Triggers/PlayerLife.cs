using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour {

    FiniteStateMachine fsm;

    int health = 10;

    [SerializeField]
    GameObject enemyClose;

    void OnTriggerStay(Collider coll)
    {
        if(coll.tag == enemyClose.tag || coll.name == "Bullet 1(Clone)")
        {
            health--;
            Debug.Log("You have been hurt: " + health + " points");
            if(health == 0){
                Debug.Log("YOU HAVE BEEN KILLED");
                Debug.Break();
            }
        }
    }
}
