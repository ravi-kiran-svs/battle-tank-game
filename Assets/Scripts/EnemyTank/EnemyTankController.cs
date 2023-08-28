using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankController {

    public TankModel tankModel;
    public EnemyTankView tankView;
    public EnemyTankService tankService;

    public Rigidbody rgbd { get; set; }

    private EnemyTankState currentState;


    public EnemyTankController(TankModel model, EnemyTankView view, Vector3 p1, Vector3 p2) {
        tankModel = model;
        tankView = view;

        tankView.SetTankController(this);

        ChangeState(tankView.GetComponent<PatrolState>());
        tankView.GetComponent<PatrolState>().patrolPoints.Add(p1);
        tankView.GetComponent<PatrolState>().patrolPoints.Add(p2);
        tankView.GetComponent<PatrolState>().target = 1;
    }

    public void Move() {
        currentState.Tick();
    }

    public void OnDeath() {
        tankService.OnDeath();
    }

    public void ChangeState(EnemyTankState newState) {
        if (currentState != null) {
            currentState.OnStateExit();
        }
        currentState = newState;
        newState.OnStateEnter(this);
    }

    public void OnTankEnteredVisibleRange(Vector3 pTank) {
        if (currentState is PatrolState) {
            ChangeState(tankView.GetComponent<ChaseState>());
            tankView.GetComponent<ChaseState>().p0 = tankView.transform.position;
            tankView.GetComponent<ChaseState>().target = pTank;
        }
    }
}
