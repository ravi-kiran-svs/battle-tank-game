using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : MonoBehaviour, EnemyTankState {

    public List<Vector3> patrolPoints = new List<Vector3>();
    public int target;

    EnemyTankController tank;

    public void OnStateEnter(EnemyTankController tankController) {
        tank = tankController;
    }

    public void OnStateExit() {
    }

    public void Tick() {
        tank.rgbd.velocity = (patrolPoints[target] - tank.rgbd.position).normalized * tank.tankModel.v_max * Time.fixedDeltaTime;
        (tank.tankView as MonoBehaviour).transform.rotation = Quaternion.LookRotation(tank.rgbd.velocity);

        if ((patrolPoints[target] - tank.rgbd.position).magnitude < 0.1) {
            target = (target + 1) % 2;
        }
    }

}
