using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController {

    private TankModel tankModel;
    private TankView tankView;
    public TankService tankService;

    public Rigidbody rgbd { private get; set; }

    public TankController(TankModel model, TankView view) {
        tankModel = model;
        tankView = view;

        tankView.SetTankController(this);
    }

    public void Move(Vector3 dir) {
        rgbd.AddForce(dir * tankModel.v_max * Time.fixedDeltaTime, ForceMode.VelocityChange);

        if (rgbd.velocity != Vector3.zero) {
            (tankView as MonoBehaviour).transform.rotation = Quaternion.LookRotation(rgbd.velocity);
        }
    }

    public void Fire(Vector3 p, Vector3 dir) {
        tankService.SpawnBullet(p, dir, tankModel.damage);
    }
}
