using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField] private bool _isGrounded;

    [Header("Player Stats")]
    [SerializeField] private float _moveSpeed = 5.0f;
    [SerializeField] private float _gravity = 9.81f;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * _moveSpeed;

        if(_controller.isGrounded == false)
        {
            velocity.y -= _gravity;
        }

        _controller.Move(velocity * Time.deltaTime);
    }
}
