using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementService : MonoBehaviour {

    [SerializeField] private BulletService bulletService;
    [SerializeField] private EnemyTankService enemyService;
    [SerializeField] private TankService tankService;

    private int nBulletsFired = 0;
    private int nEnemiesKilled = 0;

    private void Awake() {
        bulletService.OnBulletFired += OnBulletFired;
        enemyService.OnTankDeath += OnEnemyKilled;
        tankService.OnTankDead += OnTankDeathed;
    }

    private void OnTankDeathed() {
        Debug.Log("!!! Congratulations !!!");
        Debug.Log("You are Deathed.");
    }

    private void OnBulletFired() {
        nBulletsFired++;

        if (nBulletsFired == 5) {
            Debug.Log("!!! Congratulations !!!");
            Debug.Log("You fired 5 bullets.");

        } else if (nBulletsFired == 10) {
            Debug.Log("!!! Congratulations !!!");
            Debug.Log("You fired 10 bullets.");

        } else if (nBulletsFired == 25) {
            Debug.Log("!!! Congratulations !!!");
            Debug.Log("You fired 25 bullets.");
        }
    }

    private void OnEnemyKilled() {
        nEnemiesKilled++;

        if (nEnemiesKilled == 1) {
            Debug.Log("!!! Congratulations !!!");
            Debug.Log("You killed your first enemy.");


        } else if (nEnemiesKilled == 5) {
            Debug.Log("!!! Congratulations !!!");
            Debug.Log("You killed 5 enemies.");

        } else if (nEnemiesKilled == 10) {
            Debug.Log("!!! Congratulations !!!");
            Debug.Log("You killed 10 enemies.");
        }
    }

}
