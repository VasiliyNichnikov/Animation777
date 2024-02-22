#nullable enable
using System.Collections.Generic;
using Factory;
using UnityEngine;

namespace Machine
{
    /// <summary>
    /// Отображение автомата
    /// </summary>
    public class MachineView : MonoBehaviour
    {
        private ISlotFactory _slotFactory = null!;
        private IMachine _machine = null!;
        
        private readonly List<SlotView> _createdSlots = new List<SlotView>();
        
        public void Init(IMachine machine, ISlotFactory slotFactory)
        {
            _machine = machine;
            _slotFactory = slotFactory;

            CreateSlots();
        }

        private void CreateSlots()
        {
            if (_createdSlots.Count > _machine.NumberOfSlots)
            {
                while (_createdSlots.Count != _machine.NumberOfSlots)
                {
                    var temp = _createdSlots[0];
                    Destroy(temp);
                    _createdSlots.RemoveAt(0);
                }
            }

            if (_createdSlots.Count < _machine.NumberOfSlots)
            {
                while (_createdSlots.Count != _machine.NumberOfSlots)
                {
                    var slot = _slotFactory.Create();
                    _createdSlots.Add(slot);
                }
            }

            Debug.Assert(_createdSlots.Count == _machine.NumberOfSlots, "MachineView.MachineView: The number of elements diverges.");

            var index = 0;
            foreach (var slotModel in _machine.SlotModels)
            {
                _createdSlots[index].Init(slotModel);
                index++;
            }
        }
    }
}