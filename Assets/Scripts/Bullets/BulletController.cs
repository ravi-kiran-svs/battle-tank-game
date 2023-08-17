using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    private BulletView view;

    public Rigidbody rgbd;

    public BulletController(BulletView v) {
        view = v;
        view.SetBulletController(this);
    }

    public void Move(Vector3 dir) {
        rgbd.velocity = dir * view.speed * Time.fixedDeltaTime;
    }
}
