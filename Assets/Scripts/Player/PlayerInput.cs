using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : IDisposable {
    public event Action<Vector2> OnShoot;

    private PlayerInputs _playerInputs;

    public void Init () {
        _playerInputs = new PlayerInputs ();
        _playerInputs.Enable();

        _playerInputs.Screen.Click.performed += Shoot;
    }

    private void Shoot (InputAction.CallbackContext context) {
        OnShoot?.Invoke(_playerInputs.Screen.MousePosition.ReadValue<Vector2>());
    }

    public void Dispose () {
        _playerInputs.Screen.Click.performed -= Shoot;
    }
}
