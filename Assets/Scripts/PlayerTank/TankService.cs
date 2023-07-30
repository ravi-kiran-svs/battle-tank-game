using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoBehaviour {

    [SerializeField] private TankView TankPrefab;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private TankFollower cam;

    private void Start() {
        SpawnTank();
    }

    private void SpawnTank() {
        TankModel tankModel = new TankModel();

        TankView tankView = Instantiate<TankView>(TankPrefab);
        tankView.joystick = joystick;
        cam.SetTank((tankView as MonoBehaviour).transform);

        TankController tankController = new TankController(tankModel, tankView);
    }
}
