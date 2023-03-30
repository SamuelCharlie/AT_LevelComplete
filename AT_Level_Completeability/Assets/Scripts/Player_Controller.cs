using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    #region [Input Variables]
    [Header("Inputs")]
    Player_Action_Map player_inputs;

    #endregion

    #region [Player Variables]
    [Header("References")]
    public Rigidbody rbody;
    #endregion

    #region [Movement Variables]
    [Header("Movement")]
    public Vector2 movement_input;
    public Vector3 movement_direction;

    public float vertical_input = 0.0f;
    public float horizontal_input = 0.0f;
    public float movement_speed = 0.0f;
    public float rotation_speed = 0.0f;
    #endregion

    #region [Camera Variables]
    [Header("Camera")]
    public Transform player_camera;
    #endregion

    private void Awake()
    {
        rbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        if (player_inputs == null)
            player_inputs = new Player_Action_Map();

        player_inputs.Player.Movement.performed += ctx => movement_input = ctx.ReadValue<Vector2>();

        player_inputs.Enable(); 
    }

    private void OnDisable()
    {
        player_inputs.Disable();
    }
    private void Update()
    {
        HandleAllInputs();
    }

    private void FixedUpdate()
    {
        HandleAllMovement();
    }

    private void HandleAllInputs()
    {
        HandleMovementInput();
    }

    private void HandleMovementInput()
    {
        vertical_input = movement_input.y;
        horizontal_input = movement_input.x;
    }

    private void HandleAllMovement()
    {
        HandleMovement();
        HandleRotation();
    }


    private void HandleMovement()
    {
        movement_direction = player_camera.forward * vertical_input;
        movement_direction = movement_direction + player_camera.right * horizontal_input;
        movement_direction.Normalize();
        movement_direction.y = 0.0f;
        movement_direction = movement_direction * movement_speed;

        Vector3 movement_velocity = movement_direction;
        rbody.velocity = movement_velocity;
    }

    private void HandleRotation()
    {
        Vector3 target_direction = Vector3.zero;

        target_direction = player_camera.forward * vertical_input;
        target_direction = target_direction + player_camera.right * horizontal_input;
        target_direction.Normalize();
        target_direction.y = 0.0f;

        if (target_direction == Vector3.zero)
            target_direction = transform.forward;

        Quaternion target_rotation = Quaternion.LookRotation(target_direction);
        Quaternion player_rotation = Quaternion.Slerp(transform.rotation, target_rotation, rotation_speed * Time.deltaTime);

        transform.rotation = player_rotation;
    }
}
