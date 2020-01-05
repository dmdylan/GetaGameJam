using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetPlayerHighScore : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    private float highScore;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetFloat("HighScore", 0);
            highScoreText.text = PlayerPrefs.GetFloat("HighScore").ToString();
        }
    }

}
