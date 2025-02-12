using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    private Transform _transform;

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
        if (_target == null) return;

        _transform.rotation = Quaternion.Euler(0, _target.eulerAngles.y, 0);
    }
}