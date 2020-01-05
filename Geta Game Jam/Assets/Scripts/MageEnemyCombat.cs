using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageEnemyCombat : MonoBehaviour
{
    [SerializeField] private float timeBetweenAttacks;
    [SerializeField] private Transform fireLocation = null;

    public MageProjectile mageProjectile;

    void Start()
    {
        InvokeRepeating("FireAProjectile", 2, Random.Range(2.5f, 5)); 
    }

    void Update()
    {
        timeBetweenAttacks += Time.deltaTime;
    }
    
    private void FireAProjectile()
    {
        timeBetweenAttacks = 0;
        MageProjectile newProjectile = Instantiate(mageProjectile, fireLocation.position, fireLocation.rotation) as MageProjectile;
    }
}
