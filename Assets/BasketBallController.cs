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

        }
        
    }

}
