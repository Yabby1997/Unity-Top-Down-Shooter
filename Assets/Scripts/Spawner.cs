using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public Wave[] waves;	//make array of waves.

	public Enemy enemy;	//get reference of Enemy.

	Wave currentWave;	//new Wave named currentWave. to call Wave's method or something.
	int currentWaveNumber;	//wave Number. 
	int enemiesRemainingToSpawn;	//not spawned enemy
	int enemiesRemainingAlive;	//spawned enemy
	float nextSpawnTime;	//next time for spawn

	void Start(){
		NextWave();
	}

	void Update(){
		if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime) {	//if we have remaining enemies to spawn and Time is bigger than nextSpawnTime, it means we need to spawn new enemy.
			enemiesRemainingToSpawn--;	//remaining enemies to spawn - 1
			nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;	//nextSpawnTime is current time + current wave's time between spawn.
			Enemy spawnedEnemy = Instantiate(enemy, Vector3.zero, Quaternion.identity)as Enemy;	//Instantiate new Enemy named spawnedEnemy on the origin of the map, and identity rotation of prefab.
			spawnedEnemy.OnDeath += OnEnemyDeath;
		}
	}

	void OnEnemyDeath(){
		//print ("Enemy down");
		enemiesRemainingAlive --;

		if (enemiesRemainingAlive == 0) {	//if there is no more enemies alive, 
			NextWave ();	//call NextWave method to move into the next wave.
		}
	}

	void NextWave(){
		currentWaveNumber++;	//NextWave executed,
		print("Wave:" +currentWaveNumber);	//show wave number on console.
		if (currentWaveNumber - 1 < waves.Length) {	//if currentWaveNumber - 1 is bigger than waves length, that occurs error. so we need to check it earlier
			currentWave = waves [currentWaveNumber - 1];	//currentWave is waves[currentWaveNumber-1] (in computer science, 0 is new 1).
			enemiesRemainingToSpawn = currentWave.enemyCount;	//enemiesRemaingToSpawn is new Wave's enemyCount.
			enemiesRemainingAlive = enemiesRemainingToSpawn;
		}
	}

	[System.Serializable]	//enables us to change variables in inspector in Unity engine for each arrays of waves.
	public class Wave{
		public int enemyCount;
		public float timeBetweenSpawns;
	}
}
