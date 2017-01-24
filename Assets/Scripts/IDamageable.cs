//interface for notifying hit
using UnityEngine;

public interface IDamageable {	//we don't need to make any specific method in here because this class is interface class and we need to redefine those methods in other classes.

	void TakeHit (float Damage, RaycastHit hit);	//RaycastHit presents the information of hit position and something elses.

}