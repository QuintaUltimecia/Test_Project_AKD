using InventorySystem;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class InventoryRenderer : MonoBehaviour
{
    [SerializeField]
    private List<SlotRenderer> _slots = new List<SlotRenderer>(6);

    private Inventory _inventory;

    [Inject]
    private void Construct(Inventory inventory)
    {
        _inventory = inventory;
        _inventory.OnUpdateItems += UpdateRenderer;
    }

    private void OnDestroy()
    {
        if (_inventory != null)
            _inventory.OnUpdateItems -= UpdateRenderer;
    }

    private void UpdateRenderer(Item[] items)
    {
        for (int i = 0; i < items.Length; i++)
        {
            _slots[i].UpdateItem(items[i]);
        }
    }
}