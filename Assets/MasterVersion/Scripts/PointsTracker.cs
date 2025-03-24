using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointsTracker : MonoBehaviour
{
    private float timer;
    public static int score;
    public static float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (SceneManager.GetActiveScene().buildIndex == 1 && timer > 0.5f){
            score += 10;
            timer = 0;
        }
        GetComponent<TextMeshPro>().text = score.ToString();
    }

}
