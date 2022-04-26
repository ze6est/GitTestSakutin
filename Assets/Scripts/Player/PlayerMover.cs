using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _stepSize;
    [SerializeField] private float _height;

    private Vector3 _targetPosition;

    private void Start()
    {
        _player = GetComponent<Player>();
        StartCoroutine(MoveSpeed());
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if(transform.position != _targetPosition)
        {
            // двигаем персонаж к цели на определенное расстояние за кадр
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
        }
    }

    public void TryMoveUp()
    {
        if(_targetPosition.y < _height)
            SetNextPosition(_stepSize);
    }

    public void TryMoveDown()
    {
        if (_targetPosition.y > -_height)
            SetNextPosition(- _stepSize);
    }

    private void SetNextPosition(float stepSize)
    {
        _targetPosition = new Vector2(_targetPosition.x, _targetPosition.y + stepSize);
    }

    private IEnumerator MoveSpeed()
    {
        while (!_player.StopGame())
        {
            _moveSpeed += 0.12f;
            yield return new WaitForSeconds(20);
        }            
    }
}
