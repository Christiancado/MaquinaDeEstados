using UnityEngine;
using System.Collections;
using System.Timers;

public class ShootingControl : MonoBehaviour {
    [SerializeField]
    GameObject cannon;

    [SerializeField]
    GameObject bulletPrefab;

    GameObject bullet;
    bool shooting = true;
	
	void Update () {
        /*I use shooting boolean as a cool down so the player can't shoot so often*/
        /*The 0 parameter of GetMouseButtonDown it's the left click on the mouse*/
        if (Input.GetMouseButtonDown(0) && shooting)
        {

            Timer aTimer = new Timer(100);
            aTimer.Elapsed += onTimerFinish;
            aTimer.AutoReset = false;
            aTimer.Start();

            shooting = false;

            bullet = GameObject.Instantiate(bulletPrefab) as GameObject;
            bullet.transform.position = cannon.transform.position;
            /*!!!The Speed should be serialized in the context*/
            bullet.rigidbody.velocity = cannon.transform.forward */*SPEED*/ 70;
            /*The bullet gameobject is destroyed after one second THE PREFAB HAS IT´S OWN SCRIPT*/
        }
            
	}
    void onTimerFinish(System.Object source, ElapsedEventArgs e)
    {
        shooting = true;
    }
}
