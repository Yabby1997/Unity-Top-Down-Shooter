using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamageable {

	public float startingHealth;	//float that sets startingHealth. we make startingHealth as initial health for living entity.
	protected float health;	//current Health.
	protected bool dead;	//the boolean that used to check is dead or alive.

	public event System.Action OnDeath;	//new event called OnDeath returns nothing(System.Action).

	protected virtual void Start(){	//this will crash with other Start methods in other classes that extends this class. so we should make this as virtual method, and override it on those other classes.
		health = startingHealth;	//when game starts, set startingHealth as health.
	}

	public void TakeHit(float damage, RaycastHit hit){	//we need to specify the TakeHit method.
		health -= damage;	//if we hit, damage will carve the health.

		if (health <= 0 && !dead) {	//and if we are not dead + health is lower than zero, execute Die method.
			Die ();
		}
	}

	protected void Die(){	//if this method executed, the state of dead variable be true(means dead).
		dead = true;
		if (OnDeath != null) {	//if OnDeath is not null(means not called?)				What The Fuck??
			OnDeath ();	//call OnDeath and it returns null.
		}
		GameObject.Destroy (gameObject);	//when this method executed(when object's health is 0), destroy that object.
	}		
}
