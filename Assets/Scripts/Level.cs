using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    [SerializeField] private GameObject ExplosionPrefab;

    public IEnumerator DestroyEverything() {
        for (int i = 0; i < 25; i++) {
            Vector3 p = new Vector3(Random.Range(-10, 10), Random.Range(0, 20), Random.Range(-10, 10));
            Instantiate(ExplosionPrefab, p, ExplosionPrefab.transform.rotation, transform);
            yield return new WaitForSeconds(0.2f);
        }

        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
