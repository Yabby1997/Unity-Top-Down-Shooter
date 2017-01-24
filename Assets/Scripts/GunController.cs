//equipping guns or something

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

	public Transform weaponHold;	//make new Transform(locations and rotations) called weaponHold.

	public Gun startingGun;
	Gun equippedGun;	//currently equipped Gun.

	void Start(){	//when the game begins, if startingGun is appointed, than set startingGun as equippedGun.
		if (startingGun != null) {
			EquipGun (startingGun);
		}
	}

	public void EquipGun(Gun gunToEquip){	//equipping new gun.
		if(equippedGun != null){	//if currently gun is equipped than Destroy the Object of equippedGun.
			Destroy (equippedGun.gameObject);
		}
		equippedGun = Instantiate(gunToEquip, weaponHold.position, weaponHold.rotation) as Gun;	//new equippedGun is now Instantiated gunToEquip where weaponHold exists.
		equippedGun.transform.parent = weaponHold;
	}

	public void Shoot(){	//when Shoot method is executed, check is there any equippedGun. and if equippedGun is not equal null, than execute method Shoot() of equippedGun.
		if (equippedGun != null) {
			equippedGun.Shoot ();
		}
	}
}
