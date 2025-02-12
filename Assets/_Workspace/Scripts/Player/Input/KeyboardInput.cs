using UnityEngine;

public class KeyboardInput : IInput
{
    private Vector3 _currentDirection = Vector3.zero;

    public Vector3 GetDirection()
    {
        return _currentDirection;
    }

    public void Update()
    {
        _currentDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            _currentDirection += Vector3.forward;

        if (Input.GetKey(KeyCode.A))
            _currentDirection += Vector3.left;

        if (Input.GetKey(KeyCode.S))
            _currentDirection += Vector3.back;

        if (Input.GetKey(KeyCode.D))
            _currentDirection += Vector3.right;
    }
}