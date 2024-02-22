#nullable enable
using Machine;
using UnityEngine;

namespace Factory
{
    public class MachineFactory : IMachineFactory
    {
        private readonly MachineView _machinePrefab;
        private readonly SlotView _slotPrefab;
        private readonly ItemView _itemPrefab;
        
        private readonly RectTransform _parent; 
        
        public MachineFactory(MachineView machinePrefab, SlotView slotPrefab, ItemView itemPrefab, RectTransform parent)
        {
            _machinePrefab = machinePrefab;
            _slotPrefab = slotPrefab;
            _itemPrefab = itemPrefab;
            
            _parent = parent;
        }
        
        public MachineView Create(IMachine machine)
        {
            var view = Object.Instantiate(_machinePrefab, _parent, false);
            var slotFactory = new SlotFactory(_slotPrefab, _itemPrefab, view.transform);
            view.Init(machine, slotFactory);
            return view;
        }
    }
}