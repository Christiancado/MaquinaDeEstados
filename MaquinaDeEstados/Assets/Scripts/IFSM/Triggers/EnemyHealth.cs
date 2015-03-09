using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    [SerializeField]
    private int health = 50;

    [SerializeField]
    private GameObject enemy;

    /*Same Concept as the Player Health*/
    void OnTriggerEnter(Collider coll)
    {
        if(coll.name == "Bullet 1(Clone)")
        {
            health--;
            Debug.Log("Enemy Hitted! " + health);
            if (health == 0)
            {
                Destroy(enemy);
            }
        }
    }
}
