using UnityEngine.SceneManagement;
using UnityEngine;

public class EndLevelDoor : MonoBehaviour
{
    public IntValue levelCounter;
    public FloatValue enemySpawnCount;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            levelCounter.Value++;
            enemySpawnCount.Value += 5;
            SceneManager.LoadScene("Main");
        }
    }
}
