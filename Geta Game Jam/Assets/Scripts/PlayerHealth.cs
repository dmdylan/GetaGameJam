using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public PlayerProfile playerProfile;
    public FloatValue playerHealth;
   
    // Start is called before the first frame update
    void Start()
    {
        playerHealth.Value = playerProfile.health;
    }

    public void PlayerTakeDamage(float damageAmount)
    {
        playerHealth.Value -= damageAmount;
    }
}
