using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletService : MonoBehaviour {

    [SerializeField] private BulletView BulletPrefab;

    private static BulletService instance;

    public event Action OnBulletFired;

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

    private void Start() {
        GameObjectPool.Instance.StartNow(10, (GameObject)BulletPrefab);
    }

    public void SpawnBullet(Vector3 pos, Vector3 dir, float damage) {
        /*BulletView bulletView = Instantiate<BulletView>(BulletPrefab, pos, (BulletPrefab as MonoBehaviour).transform.rotation, transform);
        bulletView.dir = dir;
        bulletView.damage = damage;
        bulletView.speed = 1000;*/

        GameObject go = GameObjectPool.Instance.GetItem();
        go.SetActive(true);
        go.transform.position = pos;

        BulletView bulletView = go.GetComponent<BulletView>();
        bulletView.dir = dir;
        bulletView.damage = damage;
        bulletView.speed = 1000;

        BulletController bulletController = new BulletController(bulletView);

        OnBulletFired?.Invoke();
    }

}
