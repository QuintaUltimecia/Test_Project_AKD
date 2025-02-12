using UnityEngine;

public class MouseInput : IInputRotation
{
    private Vector2 _mousePoisition;

    public Vector2 GetDirection()
    {
        _mousePoisition.x = Input.GetAxis("Mouse Y");
        _mousePoisition.y = Input.GetAxis("Mouse X");

        return _mousePoisition;
    }
}