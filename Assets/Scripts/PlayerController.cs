using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField] private float _yVelocity = 0.0f;

    [Header("Player Stats")]
    [SerializeField] private float _moveSpeed = 5.0f;
    [SerializeField] private float _gravity = 1.0f;
    [SerializeField] private float _jumpHeight = 15.0f;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(horizontalInput, 0);
        Vector3 velocity = direction * _moveSpeed;

        if(_controller.isGrounded == true)
        {
            if(Input.GetKey(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
            }
            else
            {
                _yVelocity = 0;
            }
        }
        else
        {
            _yVelocity -= _gravity;
        }

        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);
    }
}
