using UnityEngine;
using UnityEngine.EventSystems;

public class TapPanel : MonoBehaviour, IInputRotation, IDragHandler, IEndDragHandler
{
    private Vector2 _mousePoisition;

    public Vector2 GetDirection()
    {
        return _mousePoisition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _mousePoisition.x = Input.GetAxis("Mouse Y");
        _mousePoisition.y = Input.GetAxis("Mouse X");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _mousePoisition = Vector2.zero; 
    }

    private void LateUpdate()
    {
        _mousePoisition = Vector2.zero;
    }
}