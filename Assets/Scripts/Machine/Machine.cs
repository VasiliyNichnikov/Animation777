#nullable enable
using System.Collections.Generic;
using System.Linq;
using Data;

namespace Machine
{
    public class Machine : IMachine
    {
        public int NumberOfSlots => _slots.Count;
        public IReadOnlyCollection<ISlot> SlotModels => _slots;

        private readonly MachineSettings _settings;
        private readonly List<ISlot> _slots = new List<ISlot>();
        
        public Machine(MachineSettings settings)
        {
            _settings = settings;

            for (var i = 0; i < settings.NumberOfSlots; i++)
            {
                var model = new Slot(settings.Items);
                _slots.Add(model);
            }
        }

        public void StartAnimationWithResult(IReadOnlyCollection<TypeOfItem> itemsResult)
        {
            if (itemsResult.Count != _slots.Count)
            {
                return;
            }

            var itemsResultAsArray = itemsResult.ToArray();
            for (var i = 0; i < itemsResult.Count; i++)
            {
                _slots[i].StartRotation(itemsResultAsArray[i]);
            }
        }
    }
}