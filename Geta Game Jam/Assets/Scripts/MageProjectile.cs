using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageProjectile : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 0;
    private float bulletDamage;
    public EnemyProfile enemyProfile;
    [SerializeField] private float bulletSpawnTime;
    [SerializeField] private float bulletLife;

    void Start()
    {
        bulletSpawnTime = Time.time;
        bulletDamage = enemyProfile.damage;
    }

    //Update is called once per frame
    void Update()
    {
        BulletMovement();
        //BulletLife();
    }

    private void BulletLife()
    {
        bulletLife = Time.deltaTime - bulletSpawnTime;

        if(bulletLife >= 3)
        {
            Destroy(this.gameObject);
        }
    }

    private void BulletMovement()
    {
        transform.Translate(Vector3.forward * bulletSpeed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            PlayerHealth player = collision.collider.GetComponent<PlayerHealth>();
            player.PlayerTakeDamage(bulletDamage);   
        }
        Destroy(this.gameObject);
    }
}
