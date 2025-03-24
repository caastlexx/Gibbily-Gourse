using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;

public class FinalScoreDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        GetComponent<TMP_Text>().text = PointsTracker.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
