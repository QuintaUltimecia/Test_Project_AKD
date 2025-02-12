using UnityEngine;
using InventorySystem;

namespace Pickup
{
    public class Pickup : MonoBehaviour
    {
        [SerializeField]
        private InventoryRendererOnPickup _inventoryRenderer;

        private Inventory _inventory;

        public void Add(Item item)
        {
            _inventory.Add(item);
        }

        private void Awake()
        {
            _inventory = new Inventory();
            _inventoryRenderer.Construct(_inventory);
        }
    }
}