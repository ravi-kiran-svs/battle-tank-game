
public class TankModel {
    public float v_max;
    public float max_health;
    public float damage;

    public TankModel(float v, float h, float d) {
        v_max = v;
        max_health = h;
        damage = d;
    }

    public TankModel(TankScriptableObject tso) {
        v_max = tso.v_max;
        max_health = tso.max_health;
        damage = tso.damage;
    }
}
