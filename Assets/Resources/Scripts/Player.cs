using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D), typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody2D;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;

    [SerializeField] private int _speed;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rigidBody2D.velocity = new Vector2(_joystick.Horizontal * _speed, _joystick.Vertical * _speed);

        if (_rigidBody2D.velocity.y > _speed / 2)
            _animator.SetInteger("Up", _speed / 2);
        else
            _animator.SetInteger("Up", 0);

        if (_rigidBody2D.velocity.y < _speed / -2)
            _animator.SetInteger("Down", _speed / -2);
        else
            _animator.SetInteger("Down", 0);

        if (_rigidBody2D.velocity.x > _speed / 2)
            _animator.SetInteger("Right", _speed / 2);
        else
            _animator.SetInteger("Right", 0);

        if (_rigidBody2D.velocity.x < _speed / -2)
            _animator.SetInteger("Left", _speed / -2);
        else
            _animator.SetInteger("Left", 0);
    }
}
