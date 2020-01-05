using UnityEngine;

public class Enemy : MonoBehaviour
{
    public FloatValue playerScore;
    public IntValue enemiesRemaining;
    public EnemyProfile profile;
    private Transform player;
    private float attackTimer;
    private float enemyHealth;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyHealth = profile.health;
    }

    void Update()
    {
        EnemyDeath();
        AttackTimer();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveTheEnemyTowardsPlayer();
    }

    void MoveTheEnemyTowardsPlayer()
    {
        transform.LookAt(player.position);
        var distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer > 1 && profile.type != EnemyType.Mage)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, profile.moveSpeed * Time.deltaTime);
        }
        else if (distanceToPlayer > 15 && profile.type == EnemyType.Mage)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, profile.moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = transform.position;
        }

    }
    
    public void TakeDamage(float damageAmount)
    {
        enemyHealth -= damageAmount;
    }

    void EnemyDeath()
    {
        if(enemyHealth <= 0)
        {
            playerScore.Value += profile.enemyValue;
            enemiesRemaining.Value--;
            Destroy(gameObject);
        }
    }

    private float AttackTimer()
    {
        attackTimer += Time.deltaTime;

        return attackTimer;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player" && attackTimer >= 2)
        {
            attackTimer = 0;
            PlayerHealth player = collision.collider.GetComponent<PlayerHealth>();
            player.PlayerTakeDamage(profile.damage);
        }
    }
}
