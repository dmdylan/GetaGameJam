﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public PlayerProfile playerProfile;
    public WeaponProfile weaponProfile;
    public Animator swordAnimation;
    private float attackTimer;

    // Update is called once per frame
    void Update()
    {
        PlayerAttackAction();
    }

    void PlayerAttackAction()
    {
        swordAnimation.SetBool("Attacked", false);
        attackTimer += Time.deltaTime;
        if (Input.GetButton("Fire1") && attackTimer >= weaponProfile.attackCooldown)
        {
            swordAnimation.SetBool("Attacked", true);
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

    void PlayerBlockAction()
    {
        if (Input.GetButton("Fire2"))
        {
            Debug.Log("Block Action");
        }
    }
}
