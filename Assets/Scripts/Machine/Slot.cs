#nullable enable
using System;
using System.Collections.Generic;
using Data;

namespace Machine
{
    public class Slot : ISlot
    {
        public event Action<TypeOfItem>? OnStartAnimation;
        public int NumberOfItems => _items.Count;
        public IReadOnlyCollection<IItem> ItemModels => _items;

        private readonly List<IItem> _items = new List<IItem>();

        public Slot(IReadOnlyCollection<ItemData> items)
        {
            foreach (var data in items)
            {
                var itemModel = new Item(data);
                _items.Add(itemModel);
            }
        }

        public void StartRotation(TypeOfItem result)
        {
            OnStartAnimation?.Invoke(result);
        }
    }
}