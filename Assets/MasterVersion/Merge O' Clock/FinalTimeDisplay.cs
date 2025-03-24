using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class i : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TMP_Text>().text = String.Format("{0:0.00}", Time.time - PointsTracker.startTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
