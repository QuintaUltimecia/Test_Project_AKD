using UnityEngine;

public class PositionCopier : MonoBehaviour
{
    [SerializeField]
    private Transform _copyForm;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        _transform.position = _copyForm.position;
    }
}