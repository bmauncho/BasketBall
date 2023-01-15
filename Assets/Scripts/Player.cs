using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject ball;
    public GameObject PlayerCam;
    public float BallDist = 2f;

    public float BallthrowForce = 5f;

    bool IsHoldingBall = true;
    
    // Start is called before the first frame update
    void Start()
    {
        ball.GetComponentInChildren<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsHoldingBall)
        {
            ball.transform.position = PlayerCam.transform.position + PlayerCam.transform.forward*BallDist;

            if(Input.GetMouseButtonDown(0))
            {
                IsHoldingBall= false;
                ball.GetComponentInChildren<Rigidbody>().useGravity = true;
                ball.GetComponentInChildren<Rigidbody>().AddForce(PlayerCam.transform.forward * BallthrowForce);
            }
        }
        
    }
}
