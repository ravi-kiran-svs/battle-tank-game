using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletService : MonoBehaviour {

    [SerializeField] private BulletView BulletPrefab;

    private static BulletService instance;

    public static BulletService GetInstance() {
        return instance;
    }

    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);

        } else {
            instance = this;
        }
    }

    public void SpawnBullet(Vector3 pos, Vector3 dir, float damage) {
        BulletView bulletView = Instantiate<BulletView>(BulletPrefab, pos, (BulletPrefab as MonoBehaviour).transform.rotation, transform);
        bulletView.dir = dir;
        bulletView.damage = damage;
        bulletView.speed = 1000;

        BulletController bulletController = new BulletController(bulletView);
    }

}
