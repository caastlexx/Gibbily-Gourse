using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToExplosion : MonoBehaviour
{
    // Assign the explosion material in the Inspector
    public Material explosionMaterial;

    // Reference to the Renderer component
    private Renderer objectRenderer;

    private void Start()
    {
        // Get the Renderer component on the cube
        objectRenderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the Player collided with the cube
        if (collision.gameObject.CompareTag("Player"))
        {
            // Change the material to the explosion material
            objectRenderer.material = explosionMaterial;

            // Optional: Add any additional effects, like destroying the cube after a delay
            Destroy(gameObject, 2f); // Destroy the object after 2 seconds
        }
    }
}
