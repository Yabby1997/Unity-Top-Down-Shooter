using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public LayerMask collisionMask;	//make new LayerMask named collisionMask. it need to make collision between two objects. LayerMask means object that will hit by something(in this case, projectile).

	float speed = 10;	//basic speed 10.
	float damage = 1;

	public void SetSpeed (float newSpeed){	//every Gun and Projectile has it's own speed. so we can change speed by this method.
		speed = newSpeed;
	}

	void Update () {
		float moveDistance = speed * Time.deltaTime;	//define moveDistance as speed*deltaTime.
		CheckCollisions(moveDistance);
		transform.Translate (Vector3.forward * moveDistance);	//transform translate(location). Vector3.forward means direction is forward, deltaTime * speed construct this Vector.
	}

	void CheckCollisions(float moveDistance){	//checking collision far for moveDistance.
		Ray ray = new Ray (transform.position, transform.forward);	//make new Ray named ray, it's position is the object's position itself and it head to forward.
		RaycastHit hit;	//new RaycastHit named hit.

		if (Physics.Raycast (ray, out hit, moveDistance, collisionMask, QueryTriggerInteraction.Collide)) {	//if physically, ray casted on collisionMask on moveDistance than return hit and call it Collide. 
			OnHitObject (hit);	//if object hits collisionMask, execute OnHitObject method.	
		}
	}

	void OnHitObject(RaycastHit hit){	
		//print (hit.collider.gameObject.name);	//for a test. this syntaxt notes which object hits with gameObject.
		IDamageable damageableObject = hit.collider.GetComponent<IDamageable>();	//new IDamageable damageableObject is equal to a collided object that gets all components of IDamageable.
		if (damageableObject != null) {	//if damageableObject is not a null
			damageableObject.TakeHit (damage, hit);	//than execute method of damageableObject, TakeHit.
		}
		GameObject.Destroy (gameObject);	//Destroy GameObject called gameObject(itself).
	}
}
