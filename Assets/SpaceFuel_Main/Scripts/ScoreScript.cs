using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text textoScore;

    // Start is called before the first frame update
    void Start()
    {
        textoScore .text = "YOUR SCORE: " + ShipMove.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
