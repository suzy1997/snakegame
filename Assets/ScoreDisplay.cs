using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    private snakemovement Snakemovement;
    public int digitCount = 4;

    private void Awake()
    {
        Snakemovement = FindObjectOfType<snakemovement>();
    }


    // Update is called once per frame
    void Update()
    {
        string score = Snakemovement.GetScore().ToString();
        
        GetComponent<Text>().text = score.PadLeft(digitCount, '0');
    }
}