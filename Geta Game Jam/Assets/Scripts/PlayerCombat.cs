using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public PlayerProfile playerProfile;
    public WeaponProfile weaponProfile;
    private float attackTimer;

    // Update is called once per frame
    void Update()
    {
        PlayerAttackAction();
        PlayerDodgeAction();
    }

    void PlayerAttackAction()
    {
        attackTimer += Time.deltaTime;
        if (Input.GetButton("Fire1") && attackTimer >= weaponProfile.attackCooldown)
        {
            attackTimer = 0f;
            DoAttack();
        }
    }

    private void DoAttack()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit raycastHit;

        if(Physics.Raycast(ray, out raycastHit, weaponProfile.attackRange))
        {
            if(raycastHit.collider.tag == "Enemy")
            {
                Enemy enemy = raycastHit.collider.GetComponent<Enemy>();
                enemy.TakeDamage(weaponProfile.attackDamage);
            }
        }
    }

    void PlayerDodgeAction()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Dodge clicked");
        }
    }

    void PlayerBlockAction()
    {
        if (Input.GetButton("Fire2"))
        {
            Debug.Log("Block Action");
        }
    }
}
