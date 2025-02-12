using UnityEngine;

public class RotationCopier : MonoBehaviour
{
    [SerializeField]
    private Transform _copyFrom;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        _transform.rotation = _copyFrom.rotation;
    }
}