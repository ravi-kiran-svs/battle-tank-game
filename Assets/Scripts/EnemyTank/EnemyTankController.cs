using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankController {

    private TankModel tankModel;
    private EnemyTankView tankView;
    public EnemyTankService tankService;

    public Rigidbody rgbd { private get; set; }

    int target;
    List<Vector3> waypoints;

    public EnemyTankController(TankModel model, EnemyTankView view, List<Vector3> points, int to) {
        tankModel = model;
        tankView = view;

        tankView.SetTankController(this);

        waypoints = points;
        target = (to + 1) % waypoints.Count;
    }

    public void Move() {
        rgbd.velocity = (waypoints[target] - rgbd.position).normalized * tankModel.v_max * Time.fixedDeltaTime;
        (tankView as MonoBehaviour).transform.rotation = Quaternion.LookRotation(rgbd.velocity);

        if ((waypoints[target] - rgbd.position).magnitude < 0.1) {
            target = (target + 1) % waypoints.Count;
        }
    }

    public void OnDeath() {
        tankService.OnDeath();
    }
}
