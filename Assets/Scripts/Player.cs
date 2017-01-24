//player input

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(PlayerController))]	//this syntaxt make PlayerController to get close to Player all the time.
[RequireComponent (typeof(GunController))]	//to fire the weapon, we need reference of GunController.
public class Player : LivingEntity {	//we need to extend LivingEntity which extends IDamageable and MonoBehaviour earlier

	public float moveSpeed = 5;

	Camera viewCamera;	//to Player look at the cursor, we need to make a Ray out of Camera to the ground. so we need reference of Camera.
	PlayerController controller;	//make new PlayerController as it's name controller.
	GunController gunController;	//gunController is GunController 

	protected override void Start () {	//same as Enemy class's Start method.
		base.Start();
		controller = GetComponent<PlayerController> ();	//controller gets components of PlayerController.
		gunController = GetComponent<GunController> ();	//gunController gets all components of GunController.
		viewCamera = Camera.main;	//the Camera that we've get reference is the main camera.
	}

	void Update () {
		Vector3 moveInput = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));	//Vector3 moveInput is new Vector3 that X axis is Horizontal, Y is zero and Z is vertical.
		Vector3 moveVelocity = moveInput.normalized * moveSpeed;	//make moveInput into moveVelocity to make input usuable to move the Player. need reference of PlayerController.
		controller.Move(moveVelocity);

		Ray ray = viewCamera.ScreenPointToRay (Input.mousePosition);	//new Ray is from viewCamera to the mousePosition in the Screen.
		Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
		float rayDistance;	//make new float, named rayDistance.

		if(groundPlane.Raycast(ray, out rayDistance)){	//if casted Ray on groundPlane is ray, than this syntaxt is tue, so it can executed and out rayDistance(from viewCamera to groundPlane).
			Vector3 point = ray.GetPoint(rayDistance);	//new Vector3 point is ray's rayDistance point(it means the actual point where ray and groundPlane meets).
			//Debug.DrawLine(ray.origin, point, Color.red);	//draw a line from the origin of ray to the groundPlane so we can visualize our ray.
			controller.LookAt(point);
		}

		if (Input.GetMouseButton (0)) {	//if left mouse button clicked, execute method Shoot() in gunController.
			gunController.Shoot ();
		}
	}
}
