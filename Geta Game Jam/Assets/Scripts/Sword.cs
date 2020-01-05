using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public WeaponProfile weaponProfile;
    private float attackTimer;

    void Update()
    {
        attackTimer += Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Enemy" && attackTimer >= weaponProfile.attackCooldown)
        {
            attackTimer = 0;
            Enemy enemy = collision.collider.GetComponent<Enemy>();
            enemy.TakeDamage(weaponProfile.attackDamage);
        }
    }
}
