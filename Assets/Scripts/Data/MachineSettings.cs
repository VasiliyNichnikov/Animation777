using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "MachineSettings", menuName = "Project/MachineSettings", order = 0)]
    public class MachineSettings : ScriptableObject
    {
        public int NumberOfSlots => _numberOfSlots;
        public IReadOnlyCollection<ItemData> Items => _items;

        [SerializeField] private int _numberOfSlots;
        [SerializeField] private ItemData[] _items = null!;
    }
}