using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI totalScoreText;
    [SerializeField]
    TextMeshProUGUI currentScoreText;

    private int currentScore = 0;
    public int CurrentScore
    {
        get { return currentScore; }
        set
        {
            currentScore = value;
            currentScoreText.text = string.Format(currentScoreFormat, value);
        }
    }

    const string totalScoreFormat = "Best {0}";
    const string currentScoreFormat = "{0}";

    private void Start()
    {
        InitFields();
    }

    public void InitFields()
    {
        CurrentScore = 0;
        totalScoreText.text = string.Format(totalScoreFormat, PlayerPrefs.GetInt("MaxScore").ToString());
    }

    public void IncreaseScore()
    {
        CurrentScore += 1;
    }

    public void RewriteMaxScore()
    {
        if (CurrentScore > PlayerPrefs.GetInt("MaxScore"))
            PlayerPrefs.SetInt("MaxScore", CurrentScore);
    }
}
