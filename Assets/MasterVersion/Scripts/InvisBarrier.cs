using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisBarrier : MonoBehaviour
{
    public int side;
    public Vector3 teleportPositionLeft;
    public Vector3 teleportPositionRight;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && side == 0)
        {
            PlayerController.rb.transform.position = teleportPositionLeft;
            
        } else if (other.CompareTag("Player") && side == 1)
        {
            PlayerController.rb.transform.position = teleportPositionRight;
        }
    }
}
