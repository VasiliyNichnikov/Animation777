#nullable enable
using System.Collections.Generic;

namespace Machine
{
    /// <summary>
    /// Выдаем методы для работы с автоматом
    /// </summary>
    public interface IMachine
    {
        int NumberOfSlots { get; }
        IReadOnlyCollection<ISlot> SlotModels { get; }
        
        void StartAnimationWithResult(IReadOnlyCollection<TypeOfItem> itemsResult);
    }
}