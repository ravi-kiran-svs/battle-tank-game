using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour {

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.GetComponent<EnemyTankHealthManager>()) {
            collision.collider.GetComponent<EnemyTankHealthManager>().TakeDamage();
        }

        Destroy(gameObject);
    }

}
