using InventorySystem;
using System.Collections.Generic;
using UnityEngine;

namespace Pickup
{
    public class InventoryRendererOnPickup : MonoBehaviour
    {
        [SerializeField]
        private List<Transform> _slots = new List<Transform>(6);

        private Inventory _inventory;

        public void Construct(Inventory inventory)
        {
            _inventory = inventory;
            _inventory.OnUpdateItems += UpdateRenderer;
        }

        private void OnEnable()
        {
            if (_inventory != null)
                _inventory.OnUpdateItems += UpdateRenderer;
        }

        private void OnDisable()
        {
            if (_inventory != null)
                _inventory.OnUpdateItems -= UpdateRenderer;
        }

        private void UpdateRenderer(Item[] items)
        {
            for (int i = 0; i < _slots.Count; i++)
            {
                if (items[i] != null)
                {
                    items[i].Behaviour.gameObject.SetActive(true);
                    items[i].Behaviour.transform.SetParent(_slots[i]);
                    items[i].Behaviour.transform.localPosition = Vector3.zero;
                }
            }
        }
    }
}