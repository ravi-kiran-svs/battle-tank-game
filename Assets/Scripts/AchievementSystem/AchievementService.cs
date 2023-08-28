using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementService : MonoBehaviour {

    [SerializeField] private BulletService bulletService;
    [SerializeField] private EnemyTankService enemyService;
    [SerializeField] private TankService tankService;

    [SerializeField] private Transform achievementUIContent;
    [SerializeField] private AchievementUIText achievementUIText;

    private int nBulletsFired = 0;
    private int nEnemiesKilled = 0;

    private void Awake() {
        bulletService.OnBulletFired += OnBulletFired;
        enemyService.OnTankDeath += OnEnemyKilled;
        tankService.OnTankDead += OnTankDeathed;
    }

    private void OnBulletFired() {
        nBulletsFired++;

        if (nBulletsFired == 5) {
            SpawnAchievementText("!!! Congratulations !!!\nYou fired 5 bullets.");

        } else if (nBulletsFired == 10) {
            SpawnAchievementText("!!! Congratulations !!!\nYou fired 10 bullets.");

        } else if (nBulletsFired == 25) {
            SpawnAchievementText("!!! Congratulations !!!\nYou fired 25 bullets.");
        }
    }

    private void OnEnemyKilled() {
        nEnemiesKilled++;

        if (nEnemiesKilled == 1) {
            SpawnAchievementText("!!! Congratulations !!!\nYou killed your FIRST enemy.");

        } else if (nEnemiesKilled == 5) {
            SpawnAchievementText("!!! Congratulations !!!\nYou killed 5 enemies.");

        } else if (nEnemiesKilled == 10) {
            SpawnAchievementText("!!! Congratulations !!!\nYou fired 10 bullets.");
        }
    }

    private void OnTankDeathed() {
        SpawnAchievementText("!!! Congratulations !!!\nYou are DEATHED.");
    }

    private void SpawnAchievementText(string s) {
        AchievementUIText text = Instantiate<AchievementUIText>(achievementUIText, achievementUIContent);
        text.SetText(s);
    }

}
