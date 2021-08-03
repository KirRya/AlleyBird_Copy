using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenuShow : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI restartText;

    [SerializeField]
    GameObject deathMenu;

    [SerializeField]
    GameObject restartButton;

    void TextBlinking()
    {
        float currentAlpha = restartText.alpha == 0 ? restartText.alpha = 1 : restartText.alpha = 0;
    }

    public void PlayerDeath()
    {
        deathMenu.SetActive(true);
        restartButton.SetActive(true);
        InvokeRepeating("TextBlinking", 0.3f, 0.3f);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
