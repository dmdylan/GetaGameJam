using UnityEngine;

public enum EnemyType { Orc, Goblin, Mage}

[CreateAssetMenu]
public class EnemyProfile : ScriptableObject
{
    public float health;
    public float damage;
    public float moveSpeed;
    public int enemyValue;
    public EnemyType type;
}
