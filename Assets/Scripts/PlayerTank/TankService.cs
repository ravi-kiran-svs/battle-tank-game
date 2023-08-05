using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoBehaviour {

    [SerializeField] private TankView TankPrefab;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private TankFollower cam;

    [SerializeField] private TankScriptableObject[] tankPresets;

    private void Start() {
        SpawnTank();
    }

    private void SpawnTank() {
        TankModel tankModel = new TankModel(tankPresets[Random.Range(0, 3)]);

        TankView tankView = Instantiate<TankView>(TankPrefab);
        tankView.joystick = joystick;
        cam.SetTank((tankView as MonoBehaviour).transform);

        TankController tankController = new TankController(tankModel, tankView);
        tankController.tankService = this;
    }

    public void SpawnBullet(Vector3 pos, Vector3 dir, float damage) {
        BulletService.GetInstance().SpawnBullet(pos, dir, damage);
    }
}
