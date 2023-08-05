using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TankScrObject", menuName = "ScriptableObjects/TankScrObject")]
public class TankScriptableObject : ScriptableObject {
    public float v_max;
    public float max_health;
    public float damage;
}
