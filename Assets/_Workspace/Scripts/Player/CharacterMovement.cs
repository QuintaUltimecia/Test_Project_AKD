using UnityEngine;
using Zenject;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1.0f;

    private CharacterController _controller;
    private Transform _transform;
    private IInput _input;

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position + transform.forward, 0.1f);
    }

    [Inject]
    private void Construct(IInput input)
    {
        _input = input;
    }

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _transform = transform;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_input == null) return;

        _input.Update();
        _controller.Move(_transform.TransformDirection(_input.GetDirection()) * _speed * Time.deltaTime);
    }
}