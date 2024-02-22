#nullable enable
using Machine;

namespace Factory
{
    public interface IMachineFactory
    {
        MachineView Create(IMachine machine);
    }
}