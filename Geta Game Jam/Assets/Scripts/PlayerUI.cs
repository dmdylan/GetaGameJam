using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public FloatValue playerHealth;
    public FloatValue playerScore;

    public WeaponProfile weaponProfile;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI attackValueText;

    void Update()
    {
        SetPlayerAttackValueUI();
        SetPlayerHealthUI();
        SetPlayerScoreUI();
    }

    private void SetPlayerScoreUI()
    {
        scoreText.text = "Score: " + playerScore.Value;
    }

    private void SetPlayerHealthUI()
    {
        healthText.text = "Health: " + playerHealth.Value;
    }

    private void SetPlayerAttackValueUI()
    {
        attackValueText.text = "Attack: " + weaponProfile.attackDamage;
    }
}
