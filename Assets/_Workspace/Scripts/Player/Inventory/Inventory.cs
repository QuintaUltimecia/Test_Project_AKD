using System;
using UnityEngine;

namespace InventorySystem
{
    public class Item
    {
        public Color Color { get; private set; }
        public ItemBehaviour Behaviour { get; private set; }

        public Item(Color color, ItemBehaviour behaviour)
        {
            Color = color;
            Behaviour = behaviour;
        }
    }

    public class Inventory
    {
        private Item[] _items = new Item[6];

        public event Action<Item[]> OnUpdateItems;

        public Item GetItem()
        {
            for (int i = 0; i < _items.Length; i++)
            {
                if (_items[i] != null)
                {
                    Item item = _items[i];
                    _items[i] = null;

                    OnUpdateItems?.Invoke(_items);

                    return item;
                }
            }

            return null;
        }

        public void Add(Item item)
        {
            for (int i = 0; i < _items.Length; i++)
            {
                if (_items[i] == null)
                {
                    _items[i] = item;
                    break;
                }
            }

            OnUpdateItems?.Invoke(_items);
        }

        public void Remove(Item item)
        {
            for (int i = 0; i < _items.Length; i++)
            {
                if (_items[i] == item)
                {
                    _items[i] = null;
                    break;
                }
            }

            OnUpdateItems?.Invoke(_items);
        }
    }
}