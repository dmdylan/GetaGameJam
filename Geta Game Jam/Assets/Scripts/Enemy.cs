using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyProfile profile;
    private Transform player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
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

        if (distanceToPlayer > 1.5 && profile.type != EnemyType.Mage)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, profile.moveSpeed * Time.deltaTime);
        }
        else if (distanceToPlayer > 10 && profile.type == EnemyType.Mage)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, profile.moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = transform.position;
        }

    }
}
