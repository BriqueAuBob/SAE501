using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anatidae;

public class GameBehaviour : MonoBehaviour
{
    public static bool isGameStarted = false;
    public static bool isGameOver = false;

    public static void StartGame()
    {
        isGameStarted = true;
    }
    
    public static void EndGame()
    {
        isGameOver = true;
        isGameStarted = false;
    }

    public static void QuitGame()
    {
        Application.Quit();
    }
    
    public static void RestartGame()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        //ScoreCounter.ResetScore();
    }
}
