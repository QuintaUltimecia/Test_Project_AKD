using InventorySystem;
using UnityEngine;
using UnityEngine.UI;

public class SlotRenderer : MonoBehaviour
{
    [SerializeField]
    private Image _item;

    private Color _disable = new Color(0, 0, 0, 0);

    public void UpdateItem(Item item)
    {
        if (item != null)
            _item.color = item.Color;
        else
        {
            _item.color = _disable;
        }
    }
}