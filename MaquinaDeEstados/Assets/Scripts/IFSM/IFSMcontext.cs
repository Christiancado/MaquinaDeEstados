using UnityEngine;
using System.Collections;

public interface IFSMcontext {
    /*The interface will establish a standard use of the variables needed to use
     the states*/
    Transform player { get; }
    Transform enemy { get; }
    Transform[] enemyPath { get; }

    GameObject gun { get; }

    GameObject bulletPrefab { get; }

    NavMeshAgent navAgent { get; }

    bool playerLastPosition { set; get; }

    void ChasingAndAttacking();
    void FollowPath();
    void LastPointSeen();
}
