﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemyMelee : MasterEnemyScript {

	float meleeDmg = 5f;
	float meleeHP = 10f;
	bool hasAttacked = false;

	float strength = 1f;
	float weaponAtkValue = 1f;
	float debuffs = 0;
	float attackRange = 1;

	private MasterTroopScript troop;

	public override void Start() {
		base.Start ();
		enemyHealth = meleeHP;
		enemyDamage = meleeDmg;
	}




	public  void  Update() {

		if (GameScript.turn == "EnemyTurn") {

			GameObject[] friendlyList = GameObject.FindGameObjectsWithTag("FriendlyTroop");
			foreach ( GameObject entry in friendlyList) {
				if ( Vector3.Distance (entry.transform.position, gameObject.transform.position) <= attackRange){
					if (hasAttacked == false) {
						Debug.Log ("Enemy Melee Unit: attacking!");
						troop = entry.GetComponent<MasterTroopScript> ();
						MeleeAttack atk = new MeleeAttack (1, 1, 0);
						troop.dmg (atk.getDamage ());
						hasAttacked = true;
					}
				}
			}
		}

		if (GameScript.turn == "PlayerTurn") 
			hasAttacked = false;
	}

}
