#nullable enable
using Algorithm;
using Data;
using Factory;

namespace Machine
{
    public class MachineManager : IMachineManager
    {
        private readonly MachineSettings _settings;
        private readonly IMachineFactory _machineFactory;
        private readonly IRandomItemAlgorithm _itemAlgorithm;
        
        private IMachine? _machineModel;
        
        public MachineManager(MachineSettings settings, 
            IMachineFactory machineFactory,
            IRandomItemAlgorithm itemAlgorithm)
        {
            _settings = settings;
            _machineFactory = machineFactory;
            _itemAlgorithm = itemAlgorithm;
        }
        
        public void Init()
        {
            _machineModel = new Machine(_settings);
            _machineFactory.Create(_machineModel);
        }

        public void Run()
        {
            var result = _itemAlgorithm.GenerateItems(_settings.NumberOfSlots);
            _machineModel?.StartAnimationWithResult(result);
        }
    }
}