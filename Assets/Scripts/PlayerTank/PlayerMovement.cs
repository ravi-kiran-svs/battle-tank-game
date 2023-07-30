using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private FixedJoystick joystick;

    private Rigidbody rgbd;

    [SerializeField] float v_max = 10;

    Vector3 RIGHT = new Vector3(1, 0, -1);
    Vector3 UP = new Vector3(1, 0, 1);

    Vector3 dir = Vector3.right;

    private void Awake() {
        rgbd = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        dir = RIGHT * joystick.Horizontal + UP * joystick.Vertical;
        dir = dir.normalized;
        rgbd.AddForce(dir * v_max * Time.fixedDeltaTime, ForceMode.VelocityChange);

        if (rgbd.velocity != Vector3.zero) {
            transform.rotation = Quaternion.LookRotation(rgbd.velocity);
        }
    }
}
