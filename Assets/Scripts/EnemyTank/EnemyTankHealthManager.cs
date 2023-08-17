using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankHealthManager : MonoBehaviour {

    public EnemyTankController controller;

    public void TakeDamage() {
        controller.OnDeath();
        Destroy(gameObject);
    }

}
