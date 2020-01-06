using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetPlayerHighScore : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public FloatValue highScore;

    // Start is called before the first frame update
    void Update()
    {
        highScoreText.text = PlayerPrefs.GetFloat("HighScore").ToString();
    }

}
