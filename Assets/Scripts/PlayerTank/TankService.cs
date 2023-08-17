using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoBehaviour {

    [SerializeField] private GameObject TankPrefab;
    [SerializeField] private GameObject TankDestroyPrefab;

    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private TankFollower cam;

    [SerializeField] private TankScriptableObject[] tankPresets;

    private GameObject tank;

    private void Start() {
        SpawnTank();
    }

    private void SpawnTank() {
        TankModel tankModel = new TankModel(tankPresets[Random.Range(0, 3)]);

        tank = Instantiate(TankPrefab);

        TankView tankView = tank.GetComponent<TankView>();
        tankView.joystick = joystick;
        cam.SetTank(tank.transform);

        TankController tankController = new TankController(tankModel, tankView);
        tankController.tankService = this;
    }

    public void SpawnBullet(Vector3 pos, Vector3 dir, float damage) {
        BulletService.GetInstance().SpawnBullet(pos, dir, damage);
    }

    public void OnTankDeath() {
        Vector3 p = tank.transform.position;

        Destroy(tank);

        Instantiate(TankDestroyPrefab, p, TankDestroyPrefab.transform.rotation, transform);
    }
}
