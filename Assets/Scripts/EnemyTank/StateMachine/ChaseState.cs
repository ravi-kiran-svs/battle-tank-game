using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : MonoBehaviour, EnemyTankState {

    public Vector3 p0;
    public Vector3 target;

    EnemyTankController tank;

    public void OnStateEnter(EnemyTankController tankController) {
        tank = tankController;
    }

    public void OnStateExit() {
    }

    public void Tick() {
        tank.rgbd.velocity = (target - tank.rgbd.position).normalized * tank.tankModel.v_max * Time.fixedDeltaTime;
        (tank.tankView as MonoBehaviour).transform.rotation = Quaternion.LookRotation(tank.rgbd.velocity);

        if ((target - tank.rgbd.position).magnitude < 0.1) {
            tank.ChangeState(tank.tankView.GetComponent<AttackState>());
        }
    }

}
