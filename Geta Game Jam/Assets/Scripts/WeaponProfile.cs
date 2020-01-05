using UnityEngine;

public enum WeaponType { Sword }

[CreateAssetMenu]
public class WeaponProfile : ScriptableObject
{
    public float attackRange;
    public float attackDamage;
    public float attackCooldown;

    public WeaponType weaponType;
}
