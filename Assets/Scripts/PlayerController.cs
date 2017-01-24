using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]	//to make sure that Rigidbody is attached to PlayerController everytime.
public class PlayerController : MonoBehaviour {

	Vector3 velocity;

	Rigidbody myRigidbody;	//we need colision physics. so we need to add Rigidbody and it's name is myRigidbody.

	void Start () {
		myRigidbody = GetComponent<Rigidbody> ();	//myRigidbody gets all components of Rigidbody.
	}

	public void Move(Vector3 _velocity){
		velocity = _velocity;
	}

	void FixedUpdate () {	//FixedUpdate method has less faster update speed than Update method.
		myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);	//we make player to move by compute myRigidbody's position. fixedDeltaTime is deltaTime for FixedUpdate.	
	}

	public void LookAt(Vector3 lookPoint){	//method that get lookPoint from the Player's mouse Input.
		Vector3 heightCorrectedPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);	//this syntaxt changes the lookPoint's Y axis to current one so that Player not to be fallen on the ground.
		myRigidbody.transform.LookAt(heightCorrectedPoint);	//change the direction where Player's mouse points.
	}
}
