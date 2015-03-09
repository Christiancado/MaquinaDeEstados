using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    [SerializeField]
    private int health = 30;

    

    void OnTriggerEnter(Collider coll)
    {
        /*The idea is to let the animation to enter on a certain distance and get out so it will do always the same amount of damage*/
       
        if(coll.tag == "Enemy" || coll.name == "Bullet 1(Clone)")
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
