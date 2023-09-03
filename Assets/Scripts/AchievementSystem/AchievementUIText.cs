using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementUIText : MonoBehaviour {

    private IEnumerator Start() {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    public void SetText(string s) {
        GetComponent<Text>().text = s;
    }

}
