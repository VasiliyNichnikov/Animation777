#nullable enable
using Machine;

namespace Factory
{
    public interface ISlotFactory
    {
        SlotView Create();
    }
}