#nullable enable
using System;
using Machine;
using Unity.VisualScripting;
using UnityEngine;

namespace Data
{
    [Serializable]
    public struct ItemData
    {
        public string Title => _title;
        public Sprite Icon => _icon;
        public TypeOfItem Type => _type;
        
        [SerializeField] private string _title;
        [SerializeField] private Sprite _icon;
        [SerializeField] private TypeOfItem _type;
    }
}