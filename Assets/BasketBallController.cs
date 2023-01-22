using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketBallController : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public Transform Ball;
    public Transform Arms;
    public Transform PosOverHead;
    public Transform PosDribble;
    public GameObject Player;
    public Transform _Target;

    private bool IsBallInHands = true;
    private bool IsBallFlying = false;
    private float T;
    [SerializeField]private float duration = 1f;
    [SerializeField]private float VectorArc = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsBallInHands)
        {
            if(Input.GetMouseButton(0))
            {
                // Dribble
                Ball.position = PosDribble.position+ Vector3.up*Mathf.Abs(Mathf.Sin(Time.time*5));
                Arms.localEulerAngles = Vector3.right*0;
            }
            else
            {
                //Hold over head
                Ball.position = PosOverHead.position;
                Arms.localEulerAngles = Vector3.right*215;

                //look at hoop
                Player.transform.LookAt(_Target.parent.position);
            }

            // throw Ball
            if(Input.GetMouseButton(1))
            {
                IsBallInHands = false;
                //throw ball
                IsBallFlying = true;
                T= 0f;
            }
        }

        //Ball is in the air
        if(IsBallFlying)
        {
            T += Time.deltaTime;
            float t01 = T /duration;
            Vector3 Pos_A = PosOverHead.position;
            Vector3 Pos_B = _Target.position;
            Vector3 pos = Vector3.Lerp(Pos_A,Pos_B,t01);

            //Arc
            Vector3 Arc = Vector3.up * VectorArc * Mathf.Sin(t01 *3.14f);
            
            Ball.position = pos + Arc;

            //ball is at target

            if(t01>= 1)
            {
                IsBallFlying= false;
                Ball.GetComponentInChildren<Rigidbody>().isKinematic = false;
            }
        }
    }

    public void PickUpBall()
    {
        if(!IsBallInHands && !IsBallFlying)
        {
            IsBallInHands = true;
            Ball.GetComponentInChildren<Rigidbody>().isKinematic = true;
            
        }
    }
}
