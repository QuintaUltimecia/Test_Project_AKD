using UnityEngine;
using UnityEngine.EventSystems;

public class StickInput : MonoBehaviour, IInput, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private RectTransform _stick;
    private RectTransform _rectTransform;

    private Vector3 _direction;

    public Vector3 GetDirection()
    {
        return _direction;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = eventData.position - _rectTransform.anchoredPosition;
        position = Vector2.ClampMagnitude(position, _rectTransform.sizeDelta.x / 2f);

        _stick.anchoredPosition = position;
        _direction = _stick.anchoredPosition.normalized;
        _direction.z = _direction.y;
        _direction.y = 0;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _stick.anchoredPosition = Vector2.zero;
        _direction = Vector2.zero;
    }

    public void Update()
    {

    }

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }
}