using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeDeathCam : MonoBehaviour {

    private bool playAnim = false;

    private void Update() {
        if (playAnim) {
            transform.Rotate(Vector3.up, 90 * Time.deltaTime);
        }
    }

    public void PlayAnimeDeath() {
        playAnim = true;
        GetComponent<Camera>().enabled = true;
    }

}
