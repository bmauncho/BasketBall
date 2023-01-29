using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public UI_controller uicontroller;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.GetComponent<Ball>() != null)
        {
            //Add point
            uicontroller.GetComponentInParent<UI_controller>().IncreasePoints(1);
        }
    }
}
