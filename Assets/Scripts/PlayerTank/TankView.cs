using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour {

    public FixedJoystick joystick;

    private TankController tankController;

    Vector3 RIGHT = new Vector3(1, 0, -1);
    Vector3 UP = new Vector3(1, 0, 1);

    Vector3 dir = Vector3.right;

    public Transform muzzle;

    public void SetTankController(TankController controller) {
        tankController = controller;
        tankController.rgbd = GetComponent<Rigidbody>();
    }

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            tankController.Fire(muzzle.position, transform.forward);
        }
    }

    private void FixedUpdate() {
        dir = RIGHT * joystick.Horizontal + UP * joystick.Vertical;
        dir = dir.normalized;

        tankController.Move(dir);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.GetComponent<EnemyTankView>()) {
            tankController.onDeath();
        }
    }
}
