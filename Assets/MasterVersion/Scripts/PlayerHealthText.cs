using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthText: MonoBehaviour {
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshPro>().text = PlayerHealth.playerLives.ToString();

    }
}