using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public PlayerProfile playerProfile;
    RaycastHit hit;
    Ray ray;

    // Update is called once per frame
    void Update()
    {
        PlayerAttackAction();
        PlayerDodgeAction();
    }

    void PlayerAttackAction()
    {
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("Attack clicked");
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
