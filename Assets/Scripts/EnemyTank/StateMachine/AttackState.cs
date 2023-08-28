using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : MonoBehaviour, EnemyTankState {

    EnemyTankController tank;

    public Transform muzzle;

    public void OnStateEnter(EnemyTankController tankController) {
        tank = tankController;

        StartCoroutine(ShootBullets(10));
    }

    public void OnStateExit() {
    }

    public void Tick() {
    }

    private IEnumerator ShootBullets(int n) {
        for (int i = 0; i < n; i++) {
            yield return new WaitForSeconds(0.3f);
            BulletService.GetInstance().SpawnBullet(muzzle.position, tank.tankView.transform.forward, 1);
        }

        tank.ChangeState(tank.tankView.GetComponent<IdleState>());
    }

}
