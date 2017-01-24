using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(NavMeshAgent))]	//make NavMeshAgent stick to the Enemy
public class Enemy : LivingEntity {	//we need to extend LivingEntity which extends IDamageable and MonoBehaviour earlier

	NavMeshAgent pathFinder;	//get reference of NavMeshAgent

	Transform target;	//the location(Transform) of target(in this case, Player)

	//float attackDistanceThreshold = 1.5;

	protected override void Start () {	//to override LivingEntity's Start, we should make this as override method.
		base.Start ();	//and override!
		pathFinder = GetComponent<NavMeshAgent> ();	//pathFinder gets all component of NavMeshAgent.
		target = GameObject.FindGameObjectWithTag("Player").transform;	//find the object with tag "Player" and get that location(transform) and store it in target as a Transform variable.

		StartCoroutine (UpdatePath ());	//it performs similar function of Update of FixedUpdate, but it's refreshrate could be adjusted 
	}

	void Update () {

	}

	IEnumerator UpdatePath(){	//IEnumerator+StartCoroutine is better choice for performance of game rather than Update.
		float refreshRate = .25f;	//set refreshRate variable.

		while (target != null) {	//if target is not null
			Vector3 targetPosition = new Vector3 (target.position.x, 0, target.position.z);	//targetPosition is new Vector3 that contains target's X and Z axis and Y is zero.

			if(!dead){	//if object is dead, this syntaxt has potential to occur error. so we should ask ourselves, is it dead? or alive??
				pathFinder.SetDestination (targetPosition);	//set destination of pathFinder to targetPosition.
			}

			yield return new WaitForSeconds (refreshRate);	//wait for refreshrate 
		}
	}
}
