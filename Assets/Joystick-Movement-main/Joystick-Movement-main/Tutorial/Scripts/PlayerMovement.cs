using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;

    [SerializeField] private Animator _animator;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    private Rigidbody _rigidbody;

    private Vector3 _moveVector;
    public GameObject ballController;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _moveVector = Vector3.zero;
        _moveVector.x = _joystick.Horizontal * _moveSpeed * Time.deltaTime;
        _moveVector.z = _joystick.Vertical * _moveSpeed * Time.deltaTime;

        if(_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            Vector3 direction = Vector3.RotateTowards(transform.forward, _moveVector, _rotateSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(direction);
            ballController.GetComponentInChildren<BasketBallController>().DribbleBall();

            _animator.SetBool("Run",true);
        }

        else if(_joystick.Horizontal == 0 && _joystick.Vertical == 0)
        {
            ballController.GetComponentInChildren<BasketBallController>().ShootPos();
             _animator.SetBool("Run",false);
            _animator.Play("Idle");
        }

        _rigidbody.MovePosition(_rigidbody.position + _moveVector);
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("COLLISION");
        if(other.GetComponent<Ball>() != null)
        {
            ballController.GetComponentInChildren<BasketBallController>().PickUpBall();
        }
    }
}
