using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.UIElements;


public class MoveRoad : MonoBehaviour
{

    public Vector3 startPosition;
    public Vector3 endPosition;
    public float speed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPosition;
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, endPosition) < 0.01f)
        {
            transform.position = startPosition;
        }
    }


    private void FixedUpdate()
    {
    }
}


