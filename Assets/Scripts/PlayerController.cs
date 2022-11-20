using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField] private float _yVelocity = 0.0f;
    [SerializeField] private bool _canDoubleJump;

    [Header("Player Stats")]
    [SerializeField] private float _moveSpeed = 5.0f;
    [SerializeField] private float _gravity = 1.0f;
    [SerializeField] private float _jumpHeight = 15.0f;
    [SerializeField] private float _doubleJumpHeight = 10.5f;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        PlayerJump();
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


        if (_controller.isGrounded == false)
        {
            _yVelocity -= _gravity;
        }

        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);
    }

    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _controller.isGrounded == true)
        {
            Debug.Log("Space key has been pressed!");
            _yVelocity = _jumpHeight;
            _canDoubleJump = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && _controller.isGrounded == false && _canDoubleJump == true)
        {
            _yVelocity += _doubleJumpHeight;
        }
    }
}
