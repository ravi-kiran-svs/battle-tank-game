using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : MonoBehaviour, EnemyTankState {

    public Vector3 p0;

    EnemyTankController tank;

    public void OnStateEnter(EnemyTankController tankController) {
        tank = tankController;

        p0 = tank.tankView.GetComponent<ChaseState>().p0;
    }

    public void OnStateExit() {
    }

    public void Tick() {
        tank.rgbd.velocity = (p0 - tank.rgbd.position).normalized * tank.tankModel.v_max * Time.fixedDeltaTime;
        (tank.tankView as MonoBehaviour).transform.rotation = Quaternion.LookRotation(tank.rgbd.velocity);

        if ((p0 - tank.rgbd.position).magnitude < 0.1) {
            tank.ChangeState(tank.tankView.GetComponent<PatrolState>());
        }
    }

}
