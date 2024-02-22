#nullable enable
using Machine;
using UnityEngine;

namespace Factory
{
    public class SlotFactory : ISlotFactory
    {
        private readonly SlotView _slotPrefab;
        private readonly ItemView _itemPrefab;
        private readonly Transform _parent;
        
        public SlotFactory(SlotView slotPrefab, ItemView itemPrefab, Transform parent)
        {
            _slotPrefab = slotPrefab;
            _itemPrefab = itemPrefab;
            _parent = parent;
        }
        
        public SlotView Create()
        {
            var view = Object.Instantiate(_slotPrefab, _parent, false);
            var itemFactory = new ItemFactory(_itemPrefab, view.ContentTransform);
            view.InitFactory(itemFactory);
            return view;
        }
    }
}