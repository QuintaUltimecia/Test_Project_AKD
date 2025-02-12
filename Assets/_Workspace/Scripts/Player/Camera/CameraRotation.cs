using UnityEngine;
using Zenject;

public class CameraRotation : MonoBehaviour
{
    private IInputRotation _inputRotation;

    private Transform _transform;

    private float _x;
    private float _y;

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position + transform.forward, 0.1f);
    }

    [Inject]
    private void Construct(IInputRotation inputRotation)
    {
        _inputRotation = inputRotation;
    }

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        _x -= _inputRotation.GetDirection().x;
        _y += _inputRotation.GetDirection().y;

        _x = Mathf.Clamp(_x, -90f, 90f );

        _transform.rotation = Quaternion.Euler(_x, _y, 0);
    }
}