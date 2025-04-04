using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public GameObject textScore;
    private static int score = 0;
    private static int lastUpdate = 0;

    public static void AddScore()
    {
        if(!GameBehaviour.isGameStarted) return;
        if (Time.time - lastUpdate < 1f)
        {
            return;
        }
        lastUpdate = (int)Time.time;
        score++;
        if(GameBehaviour.isBoosting) score++;
    }

    public static void ResetScore()
    {
        score = 0;
    }

    void Update()
    {
        textScore.SetActive(GameBehaviour.isGameStarted);
        textScore.GetComponent<TextMeshProUGUI>().text = score.ToString();
    }
    
    public static int GetScore()
    {
        return score;
    }
}
