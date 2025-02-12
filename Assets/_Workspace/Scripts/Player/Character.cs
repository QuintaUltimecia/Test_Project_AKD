using UnityEngine;
using InventorySystem;
using Zenject;

public class Character : MonoBehaviour
{
    [SerializeField]
    private RaycastHandler _raycastHandler;

    private Inventory _inventory;

    [Inject]
    private void Construct(Inventory inventory)
    {
        _inventory = inventory;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_raycastHandler.TryGetRaycast(out ItemBehaviour item))
            {
                _inventory.Add(item.GetItem());
            }
            else if (_raycastHandler.TryGetRaycast(out Pickup.Pickup pickup))
            {
                Item getitem = _inventory.GetItem();

                if (getitem != null)
                    pickup.Add(getitem);
            }
        }
    }
}