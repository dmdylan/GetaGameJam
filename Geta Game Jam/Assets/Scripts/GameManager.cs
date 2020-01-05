using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public WeaponProfile weaponProfile;
    public FloatValue enemyCount;
    public IntValue enemiesRemaining;
    public IntValue levelCounter;
    public FloatValue playerHealth;
    public FloatValue playerScore;

    public GameObject endDoor;

    void Awake()
    {
        enemiesRemaining.Value = 0;
        endDoor.SetActive(false);
    }

    void Start()
    {
        ReducePowerOfPlayer();
    }

    void Update()
    {
        CheckIfPlayerIsDead();        
        EnableEndLevelDoor();
    }

    private void CheckIfPlayerIsDead()
    {
        if(playerHealth.Value <= 0)
        {
            SetHighScore();
            Initiate.Fade("Menu", Color.black, 3f);
        }
    }

    private void EnableEndLevelDoor()
    {
        if (enemiesRemaining.Value == 0)
        {
            endDoor.SetActive(true);
        }
    }

    private void ReducePowerOfPlayer()
    {
        if (weaponProfile.attackDamage <= 5 || levelCounter.Value == 0)
            return;

        weaponProfile.attackDamage--;
    }

    private void SetHighScore()
    {
        if (playerScore.Value > PlayerPrefs.GetFloat("HighScore"))
            PlayerPrefs.SetFloat("HighScore", playerScore.Value);
    }
}
