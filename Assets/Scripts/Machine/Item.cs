#nullable enable
using Data;
using UnityEngine;

namespace Machine
{
    public class Item : IItem
    {
        public Sprite Icon => _data.Icon;
        public string Title => _data.Title;
        public TypeOfItem Type => _data.Type;

        private readonly ItemData _data; 
        
        public Item(ItemData data)
        {
            _data = data;
        }
    }
}