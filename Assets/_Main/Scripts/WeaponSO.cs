using UnityEngine;

public abstract class WeaponSO : ScriptableObject {

    public string weaponName = "New Weapon";
    public Sprite sprite;
    public float fireRate = 5f;
    public float range = 100f;
    public float damage = 10f;


    public abstract void Initialize(GameObject gameObject);
    public abstract void Fire();

    


}
