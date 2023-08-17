using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankService : MonoBehaviour {

    [SerializeField] private EnemyTankView EnemyTankPrefab;
    [SerializeField] private GameObject EnemyTankExplodePrefab;
    [SerializeField] private Transform path;

    private int num_tanks = 0;

    private int max_num_tanks = 5;
    private List<Vector3> waypoints = new List<Vector3>();

    private void Start() {
        for (int i = 0; i < path.childCount; i++) {
            waypoints.Add(path.GetChild(i).transform.position);
        }

        InvokeRepeating("SpawnEnemyTank", 0, 10);
    }

    private void SpawnEnemyTank() {
        if (num_tanks < max_num_tanks) {

            TankModel tankModel = new TankModel(100, 100, 20);

            int point = Random.Range(0, waypoints.Count);
            EnemyTankView tankView = Instantiate<EnemyTankView>(EnemyTankPrefab, waypoints[point], EnemyTankPrefab.transform.rotation, transform);

            EnemyTankController tankController = new EnemyTankController(tankModel, tankView, waypoints, point);
            tankController.tankService = this;

            num_tanks++;
        }
    }

    public void OnDeath() {
        num_tanks--;
    }

    public void OnGameOver() {
        CancelInvoke();

        for (int i = 0; i < num_tanks + 1; i++) {
            GameObject tank = transform.GetChild(i).gameObject;

            if (tank.GetComponent<EnemyTankView>()) {
                Vector3 p = tank.transform.position;
                Destroy(transform.GetChild(i).gameObject);
                Instantiate(EnemyTankExplodePrefab, p, EnemyTankExplodePrefab.transform.rotation, transform);
            }
        }
    }
}
