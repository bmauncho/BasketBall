using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_controller : MonoBehaviour
{
    public int Score;
    public TMP_Text Points;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Points.text = "Points" + ":" + Score.ToString();
    }

    public void IncreasePoints(int points)
    {   
        Score += points;
    }
}
