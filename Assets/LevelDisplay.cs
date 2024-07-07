using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour
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
        string level = Snakemovement.GetLevel().ToString();
        
        GetComponent<Text>().text = level.PadLeft(digitCount, '0');
    }
}