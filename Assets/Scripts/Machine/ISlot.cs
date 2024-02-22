#nullable enable
using System;
using System.Collections.Generic;

namespace Machine
{
    public interface ISlot
    {
        event Action<TypeOfItem>? OnStartAnimation; 
        
        int NumberOfItems { get; }
        IReadOnlyCollection<IItem> ItemModels { get; }
        
        void StartRotation(TypeOfItem result);
    }
}