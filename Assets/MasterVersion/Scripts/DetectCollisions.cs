using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DetectCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Destory the collectible
            Destroy(gameObject);
            PlayerHealth.playerLives--;
            Debug.Log(PlayerHealth.playerLives);
        }
    }
}
