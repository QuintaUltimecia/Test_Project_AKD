using UnityEngine;

namespace InventorySystem
{
    public class ItemBehaviour : MonoBehaviour
    {
        [field: SerializeField]
        public Color Color { get; private set; }

        private Item _item;
        private GameObject _gameObject;

        public Item GetItem()
        {
            _gameObject.SetActive(false);
            return _item;
        }

        private void Awake()
        {
            _item = new Item(Color, this);
            _gameObject = gameObject;
        }
    }
}