using UnityEngine;
using System.Collections;

public class DestoyBullet : MonoBehaviour {
    
    void Update()
    {
        Destroy(this.gameObject, 10f);
    }
}
