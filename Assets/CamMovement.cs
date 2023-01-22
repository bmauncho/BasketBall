using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public Transform Pivot;
    public Vector3 _Offset;
    [SerializeField] private Transform _player;

    [SerializeField] private float _speed;

    private void Awake()
    {
        _Offset = Pivot.position - _player.position;
    }

    private void Update()
    {
        Follow();
    }

    private void Follow()
    {
        Pivot.DOMoveX(_player.position.x +  _Offset.x, _speed * Time.deltaTime);
        Pivot.DOMoveZ(_player.position.z + _Offset.z, _speed * Time.deltaTime);
    }
}
