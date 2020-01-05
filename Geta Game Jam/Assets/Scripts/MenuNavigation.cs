using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    public IntValue levelCounter;
    public FloatValue playerHealth;
    public FloatValue playerScore;
    public FloatValue enemySpawnCounter;
    public IntValue currentEnemyCount;

    public PlayerProfile playerProfile;

    public void StartTheGame()
    {
        levelCounter.Value = 0;
        playerScore.Value = 0;
        enemySpawnCounter.Value = 100;
        currentEnemyCount.Value = 0;
        playerHealth.Value = playerProfile.health;
        Initiate.Fade("Main", Color.black, 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
