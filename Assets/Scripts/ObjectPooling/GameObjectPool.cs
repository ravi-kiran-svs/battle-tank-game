using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : ServicePool<GameObject> {

    private GameObject Prefab;

    public override void ItsTime(int n, GameObject prefab) {
        Debug.Log("LOL");
        Prefab = prefab;
        pooledItems = new Queue<PooledItem<GameObject>>();

        for (int i = 0; i < n; i++) {
            CreateAndAdd(prefab);
        }
    }

    public override GameObject GetItem() {
        if (pooledItems.Count == 0) {
            CreateAndAdd(Prefab);
        }
        return pooledItems.Dequeue().item;
    }

    public override void ReturnItem(GameObject go) {
        pooledItems.Enqueue(new PooledItem<GameObject>(go));
    }

    protected override void CreateAndAdd(GameObject prefab) {
        GameObject go = Instantiate(prefab, transform);
        go.SetActive(false);
        pooledItems.Enqueue(new PooledItem<GameObject>(go));
    }
}
