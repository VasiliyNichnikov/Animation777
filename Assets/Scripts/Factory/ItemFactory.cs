#nullable enable
using Machine;
using UnityEngine;

namespace Factory
{
    public class ItemFactory : IItemFactory
    {
        private readonly ItemView _itemPrefab;
        private readonly Transform _parent;

        public ItemFactory(ItemView itemPrefab, Transform parent)
        {
            _itemPrefab = itemPrefab;
            _parent = parent;
        }
        
        public ItemView Create()
        {
            var view = Object.Instantiate(_itemPrefab, _parent, false);
            return view;
        }
    }
}