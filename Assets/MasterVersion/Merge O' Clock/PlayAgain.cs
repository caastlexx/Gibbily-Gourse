using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    public void PlayGame()
    {
        PlayerHealth.playerLives = 3;
        PointsTracker.score = 0;
        PlayerController.waterBottle = false;
        SceneManager.LoadScene(1);
    }


}