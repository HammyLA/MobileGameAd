using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractPerformed;
    public event EventHandler OnMenuPerformed;
    public static GameInput instance {  get; private set; }

    [SerializeField] private float speed;
    PlayerInputs playerInputs;
    private void Awake()
    {
        instance = this;
        playerInputs = new PlayerInputs();
        playerInputs.Player.Enable();

        playerInputs.Player.Interact.performed += Interact_performed;
        playerInputs.Player.Menu.performed += Menu_performed;

    }

    private void OnDestroy()
    {
        playerInputs.Player.Interact.performed -= Interact_performed;
        playerInputs.Player.Menu.performed -= Menu_performed;
        playerInputs.Dispose();
    }

    private void Menu_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnMenuPerformed?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractPerformed?.Invoke(this, EventArgs.Empty);
    }

    private void Start()
    {
        instance = this;
    }

    public void DisablePlayerInputs()
    {
        playerInputs.Player.Disable();
    }

    public void EnablePlayerInputs()
    {
        playerInputs.Player.Enable();
    }

    public Vector2 getNormalizedMovementVector()
    {
        Vector2 inputVector = playerInputs.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized * speed;

        return inputVector;
    }


}
