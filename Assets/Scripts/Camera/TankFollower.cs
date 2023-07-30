using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankFollower : MonoBehaviour {

    private Transform tank;

    Vector3 initPos;
    Vector3 tankInitPos;

    public void SetTank(Transform t) {
        tank = t;
        initPos = transform.position;
        tankInitPos = tank.position;
    }

    private void Update() {
        if (tank) {
            transform.position = initPos + (tank.position - tankInitPos);
        }
    }

}
