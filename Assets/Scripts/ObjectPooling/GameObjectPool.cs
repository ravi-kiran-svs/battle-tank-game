using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour {

    protected Queue<PooledItem<GameObject>> pooledItems = new Queue<PooledItem<GameObject>>();

    private GameObject Prefab;

    private static GameObjectPool instance;
    public static GameObjectPool Instance { get { return instance; } }

    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);

        } else {
            instance = this;
        }
    }

    public void StartNow(int n, GameObject prefab) {
        Debug.Log("LOL");
        Prefab = prefab;
        pooledItems = new Queue<PooledItem<GameObject>>();

        for (int i = 0; i < n; i++) {
            CreateAndAdd(prefab);
        }
    }

    public GameObject GetItem() {
        if (pooledItems.Count == 0) {
            CreateAndAdd(Prefab);
        }
        return pooledItems.Dequeue().item;
    }

    public void ReturnItem(GameObject go) {
        pooledItems.Enqueue(new PooledItem<GameObject>(go));
    }

    protected void CreateAndAdd(GameObject prefab) {
        GameObject go = Instantiate(prefab, transform);
        go.SetActive(false);
        pooledItems.Enqueue(new PooledItem<GameObject>(go));
    }
}
