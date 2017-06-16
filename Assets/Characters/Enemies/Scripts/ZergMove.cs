using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

public class ZergMove : MonoBehaviour {

	[SerializeField] float notChaseRadius = 2f;
    private Transform player;
    private NavMeshAgent nav;
    private Animator anim;

    private void Awake()
    {
        Assert.IsNotNull(player);
    }

    // Use this for initialization
    void Start () {

        player = GameManager.instance.Player.transform;
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        
	}

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);
        
       nav.SetDestination(player.position);
        
    }

}
