using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankView : MonoBehaviour {

    private EnemyTankController tankController;

    public void SetTankController(EnemyTankController controller) {
        tankController = controller;
        tankController.rgbd = GetComponent<Rigidbody>();

        GetComponent<EnemyTankHealthManager>().controller = controller;
    }

    private void FixedUpdate() {
        tankController.Move();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<TankView>()) {
            tankController.OnTankEnteredVisibleRange(other.transform.position);
        }
    }
}
