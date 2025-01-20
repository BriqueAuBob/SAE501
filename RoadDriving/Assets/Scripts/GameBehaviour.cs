using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    public static void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        ScoreCounter.ResetScore();
    }
}
