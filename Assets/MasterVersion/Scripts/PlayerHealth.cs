using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth: MonoBehaviour {
    public static int playerLives = 3;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (playerLives <= 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}