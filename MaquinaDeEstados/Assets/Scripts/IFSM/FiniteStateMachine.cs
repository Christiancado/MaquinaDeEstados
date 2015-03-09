using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class FiniteStateMachine : MonoBehaviour, IFSMcontext {

    private List<State> states;
    private State curState;
    private AIstate curStateId;
     [SerializeField]
    private AIstate initialStateId;

    private bool _playerLastPosition;
    public bool playerLastPosition
    {
        set { _playerLastPosition = value; }
        get { return _playerLastPosition; }
    }

    [SerializeField]
    private Transform _player;
    public Transform player
    {
        get { return _player; }
    }

    [SerializeField]
    private Transform _enemy;
    public Transform enemy
    {
        get { return _enemy; }
    }

    [SerializeField]
    private GameObject _gun;
    public GameObject gun
    {
        get { return _gun; }
    }

    [SerializeField]
    private GameObject _bullet;
    public GameObject bulletPrefab
    {
        get { return _bullet; }
    }


    [SerializeField]
    private Transform[] _enemyPath;
    public Transform[] enemyPath
    {
        get { return _enemyPath; }
    }

    [SerializeField]
    private NavMeshAgent _navAgent;
    public NavMeshAgent navAgent
    {
        get { return _navAgent; }
    }


    void Start () {
        setupStates();
        curState = states[(int)initialStateId];
        navAgent.SetDestination(enemyPath[0].position);
	}
    

	// onUpdate is called once per frame
	void Update () {
	    curState.onUpdate();
	}

   

    public void ChasingAndAttacking()
    {
        curState = states[(int)AIstate.ChasingAndAttaking];
    }

    public void FollowPath()
    {
        curState = states[(int)AIstate.FollowPath];
    }

    public void LastPointSeen()
    {
        curState = states[(int)AIstate.ChaseToLastPointSeen];
    }

    private void setupStates()
    {

        string[] stateIds = Enum.GetNames(typeof(AIstate));
        states = new List<State>();
        for (int i = 0; i < stateIds.Length; i++)
        {

            object param = this;
            /*Magia negra*/
            State parsedState = Activator.CreateInstance(Type.GetType(stateIds[i], true), param) as State;
            states.Add(parsedState);


        }
    }



   
}
