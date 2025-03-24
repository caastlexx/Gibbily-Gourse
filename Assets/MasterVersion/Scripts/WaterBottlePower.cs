using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBottlePower : MonoBehaviour
{
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        PlayerController.waterBottle = false;
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
            PointsTracker.score += 300;

            
        }
    }
}
