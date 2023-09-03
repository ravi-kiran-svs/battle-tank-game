using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour {
    public Vector3 dir;
    public float damage;
    public float speed;

    public BulletController bulletController;

    public void SetBulletController(BulletController controller) {
        bulletController = controller;
        bulletController.rgbd = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        bulletController.Move(dir);
    }

    public static explicit operator GameObject(BulletView v) {
        throw new NotImplementedException();
    }
}
