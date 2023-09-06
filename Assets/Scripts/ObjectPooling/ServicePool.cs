using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServicePool<T> : MonoSingleton<ServicePool<T>> {

    protected Queue<PooledItem<T>> pooledItems;

    public virtual void ItsTime(int n, T t) { }

    public virtual T GetItem() { return pooledItems.Dequeue().item; }

    public virtual void ReturnItem(T t) { }

    protected virtual void CreateAndAdd(T t) { }

}

public class PooledItem<T> {
    public T item;
    public bool isUsed = false;

    public PooledItem(T t) {
        item = t;
    }
}
