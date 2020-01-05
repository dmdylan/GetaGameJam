using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public PlayerProfile playerProfile;
    public FloatValue playerHealth;
   
    public void PlayerTakeDamage(float damageAmount)
    {
        playerHealth.Value -= damageAmount;
    }
}
