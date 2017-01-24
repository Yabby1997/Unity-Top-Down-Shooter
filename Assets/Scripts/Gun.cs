using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
	
	public Transform muzzle;	//the location that bullets coming out.
	public Projectile projectile;	//variable that sets which projectile to shoot.
	public float msBetweenShots = 100;	//time between shots.
	public float muzzleVelocity = 35;	//the bullets speed.

	public float nextShotTime;


	public void Shoot(){
		if(Time.time > nextShotTime){	//if current time is bigger than nextShotTime, than nextShotTime is currentTime + msBetweenShots/1000 so there's a term between shots.
			nextShotTime = Time.time + msBetweenShots / 1000;
			Projectile newProjectile = Instantiate (projectile, muzzle.position, muzzle.rotation) as Projectile;	//make newProjectile and Instantiate at muzzle's position and it's rotation as Projectile.
			newProjectile.SetSpeed (muzzleVelocity);	//the value we set up on the field, muzzleVelocity is the newProjectile's newSpeed.
		}
	}
}
