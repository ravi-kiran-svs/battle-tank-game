using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour {

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.GetComponent<EnemyTankHealthManager>()) {
            collision.collider.GetComponent<EnemyTankHealthManager>().TakeDamage();

        } else if (collision.collider.GetComponent<TankView>()) {
            collision.collider.GetComponent<TankView>().tankController.onDeath();
        }

        /*Destroy(gameObject);*/

        GameObjectPool.Instance.ReturnItem(gameObject);
    }

}
